using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;
using QuickPuzzle.Test.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using QuickPuzzle.EntityFactory;
using QuickPuzzle.Test.EntityFrameworkCore;

namespace QuickPuzzle.Test
{
    public class RepositoryTestAppService : TestAppService, IRepositoryTestAppService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DefaultEntityFactory _entityFactory;
        private readonly object repository;

        public RepositoryTestAppService(
            IServiceProvider serviceProvider,
            DefaultEntityFactory entityFactory,
            TestDbContext dbContext)
        {
            _serviceProvider = serviceProvider;
            _entityFactory = entityFactory;
            var repositoryType = typeof(IRepository<,>);
            Type[] typeArgs = { _entityFactory.GetEntity("test"), typeof(Guid) };
            var ge = repositoryType.MakeGenericType(typeArgs);
            // var obj = Activator.CreateInstance(ge);
            repository = _serviceProvider.GetService(ge);
        }

        public object Test()
        {
            return repository;
        }
    }
}
