using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace QuickPuzzle.DomainObject.EntityFrameworkCore
{
    public class DomainObjectModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public DomainObjectModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}