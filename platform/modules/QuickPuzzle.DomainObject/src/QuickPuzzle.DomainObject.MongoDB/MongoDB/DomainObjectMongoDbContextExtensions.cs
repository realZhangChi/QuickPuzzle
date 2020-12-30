using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace QuickPuzzle.DomainObject.MongoDB
{
    public static class DomainObjectMongoDbContextExtensions
    {
        public static void ConfigureDomainObject(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DomainObjectMongoModelBuilderConfigurationOptions(
                DomainObjectDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}