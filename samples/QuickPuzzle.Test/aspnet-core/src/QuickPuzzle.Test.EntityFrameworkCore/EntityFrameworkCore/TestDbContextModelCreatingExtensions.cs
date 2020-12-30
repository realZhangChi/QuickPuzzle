using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using QuickPuzzle.EntityFactory;

namespace QuickPuzzle.Test.EntityFrameworkCore
{
    public static class TestDbContextModelCreatingExtensions
    {
        public static void ConfigureTest(this ModelBuilder builder, DefaultEntityFactory entityFactory)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(TestConsts.DbTablePrefix + "YourEntities", TestConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            var type = entityFactory.GetEntity("test");
            builder.Entity(type, b => {
                b.ConfigureByConvention();
            });
        }
    }
}