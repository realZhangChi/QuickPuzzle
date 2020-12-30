using System;
using Volo.Abp.Modularity;
using Volo.Abp.Domain;

namespace QuickPuzzle.EntityFactory
{
    [DependsOn(typeof(AbpDddDomainModule))]
    public class QuickPuzzleEntityFactoryModule : AbpModule
    {
    }
}
