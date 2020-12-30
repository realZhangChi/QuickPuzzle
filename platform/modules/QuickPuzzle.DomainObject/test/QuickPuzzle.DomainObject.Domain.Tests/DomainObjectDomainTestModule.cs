using QuickPuzzle.DomainObject.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace QuickPuzzle.DomainObject
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(DomainObjectEntityFrameworkCoreTestModule)
        )]
    public class DomainObjectDomainTestModule : AbpModule
    {
        
    }
}
