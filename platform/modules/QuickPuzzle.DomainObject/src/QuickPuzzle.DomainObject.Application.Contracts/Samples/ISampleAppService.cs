using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace QuickPuzzle.DomainObject.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
