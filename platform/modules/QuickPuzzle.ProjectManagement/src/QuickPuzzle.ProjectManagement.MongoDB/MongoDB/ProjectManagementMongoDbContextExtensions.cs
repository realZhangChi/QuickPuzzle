using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace QuickPuzzle.ProjectManagement.MongoDB
{
    public static class ProjectManagementMongoDbContextExtensions
    {
        public static void ConfigureProjectManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ProjectManagementMongoModelBuilderConfigurationOptions(
                ProjectManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}