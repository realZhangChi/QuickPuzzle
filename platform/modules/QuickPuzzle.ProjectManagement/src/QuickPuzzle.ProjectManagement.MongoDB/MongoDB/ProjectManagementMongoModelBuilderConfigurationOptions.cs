using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace QuickPuzzle.ProjectManagement.MongoDB
{
    public class ProjectManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public ProjectManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}