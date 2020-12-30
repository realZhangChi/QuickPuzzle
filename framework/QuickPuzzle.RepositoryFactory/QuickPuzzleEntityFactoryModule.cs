using System;
using Volo.Abp.Modularity;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;

namespace QuickPuzzle.RepositoryFactory
{
    [DependsOn(typeof(AbpBackgroundJobsEntityFrameworkCoreModule))]
    public class QuickPuzzleEntityFactoryModule : AbpModule
    {
    }
}
