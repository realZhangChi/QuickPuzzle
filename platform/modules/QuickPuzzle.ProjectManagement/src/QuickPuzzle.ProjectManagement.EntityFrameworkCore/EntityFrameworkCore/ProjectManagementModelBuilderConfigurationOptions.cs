using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace QuickPuzzle.ProjectManagement.EntityFrameworkCore
{
    public class ProjectManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ProjectManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}