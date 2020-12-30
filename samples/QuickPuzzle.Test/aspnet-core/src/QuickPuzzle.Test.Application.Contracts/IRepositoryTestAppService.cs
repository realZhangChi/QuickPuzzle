using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;
using QuickPuzzle.Test.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using QuickPuzzle.EntityFactory;
using Volo.Abp.Application.Services;

namespace QuickPuzzle.Test
{
    public interface IRepositoryTestAppService : IApplicationService
    {
        object Test();
    }
}
