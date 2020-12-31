using System.Collections.Generic;
using System;
using System.Linq;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Localization;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using StackExchange.Redis;
using Volo.Abp;
using Volo.Abp.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Security.Claims;
using QuickPuzzle.MultiTenancy;

namespace QuickPuzzle.PlatformGateway
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpSwashbuckleModule)
    )]
    [DependsOn(typeof(AbpPermissionManagementDomainIdentityModule))]
    [DependsOn(typeof(AbpPermissionManagementDomainIdentityServerModule))]
    [DependsOn(typeof(AbpIdentityDomainModule))]
    [DependsOn(typeof(AbpIdentityEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpIdentityHttpApiModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreMySQLModule))]
    [DependsOn(typeof(AbpPermissionManagementApplicationModule))]
    [DependsOn(typeof(AbpPermissionManagementHttpApiModule))]
    [DependsOn(typeof(AbpPermissionManagementEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpSettingManagementEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpTenantManagementApplicationModule))]
    [DependsOn(typeof(AbpTenantManagementHttpApiModule))]
    [DependsOn(typeof(AbpTenantManagementEntityFrameworkCoreModule))]
    public class PlatformGatewayHttpApiHostModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            ConfigureDbContext();
            ConfigureMultiTenancy();
            ConfigureSwaggerServices(context, configuration);
            ConfigureLocalization();
            ConfigureAuthentication(context, configuration);
            ConfigureDataProtection(context, configuration);
            ConfigureCors(context, configuration);
            ConfigureCookiePolicy();
            // ConfigureDistributedCache(context, configuration);
            ConfigureOcelot(context, configuration);
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            app.UseCorrelationId();
            app.UseVirtualFiles();
            app.UseRouting();
            app.UseCors(DefaultCorsPolicyName);
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseAbpSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatformGateway API");
            });

            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }

        private void ConfigureDbContext()
        {
            Configure<AbpDbContextOptions>(options =>
                       {
                           options.UseMySQL();
                       });
        }

        private void ConfigureDistributedCache(ServiceConfigurationContext context, IConfiguration configuration)
        {
            Configure<AbpDistributedCacheOptions>(options =>
            {
                options.KeyPrefix = "ManagementGateway:";
            });

            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });
        }
        private void ConfigureMultiTenancy()
        {
            Configure<AbpMultiTenancyOptions>(options =>
                        {
                            options.IsEnabled = MultiTenancyConsts.IsEnabled;
                        });
        }

        private void ConfigureDataProtection(ServiceConfigurationContext context, IConfiguration configuration)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            if (!hostingEnvironment.IsDevelopment())
            {
                var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
                context.Services.AddDataProtection()
                    .PersistKeysToStackExchangeRedis(redis, "ManagementGateway-DataProtection-Keys");
            }
        }
        private void ConfigureCookiePolicy()
        {
            Configure<CookiePolicyOptions>(options =>
                        {
                            options.ConfigSameSite();
                        });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            //Updates AbpClaimTypes to be compatible with identity server claims.
            AbpClaimTypes.UserId = JwtClaimTypes.Subject;
            AbpClaimTypes.UserName = JwtClaimTypes.Name;
            AbpClaimTypes.Role = JwtClaimTypes.Role;
            AbpClaimTypes.Email = JwtClaimTypes.Email;
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.ApiName = configuration["AuthServer:ApiName"];
                });
        }

        private void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAbpSwaggerGenWithOAuth(
                            configuration["AuthServer:Authority"],
                            new Dictionary<string, string>
                            {
                    {"ManagementGateway", "ManagementGateway API"},
                    {"TouristAttractions", "TouristAttractions API"},
                    {"GeneralSettings", "GeneralSettings API"},
                    {"IdentityManagement", "IdentityManagement API"},
                    {"PermissionManagement", "PermissionManagement API"},
                    {"TenantManagement", "TenantManagement API"}
                            },
                            options =>
                            {
                                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Mobile Gateway API", Version = "v1" });
                                options.DocInclusionPredicate((docName, description) => true);
                                options.CustomSchemaIds(type => type.FullName);
                            });
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            });
        }

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        private void ConfigureOcelot(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddOcelot(configuration);
        }

    }
}
