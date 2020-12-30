using QuickPuzzle.Test.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace QuickPuzzle.Test.Controllers
{
    /* Inherit your controllers from this class.
     */
    [Route("/api/test")]
    public class RepositoryTestController : TestController
    {
        private readonly IRepositoryTestAppService _service;

        public RepositoryTestController(IRepositoryTestAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public object Test()
        {
            return _service.Test();
        }
    }
}