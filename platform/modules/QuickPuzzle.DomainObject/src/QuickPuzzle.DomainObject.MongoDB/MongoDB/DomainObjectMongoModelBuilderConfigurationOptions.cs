using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace QuickPuzzle.DomainObject.MongoDB
{
    public class DomainObjectMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public DomainObjectMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}