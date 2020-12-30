using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuickPuzzle.Test.Data;
using Volo.Abp.DependencyInjection;

namespace QuickPuzzle.Test.EntityFrameworkCore
{
    public class EntityFrameworkCoreTestDbSchemaMigrator
        : ITestDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreTestDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the TestMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<TestMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}