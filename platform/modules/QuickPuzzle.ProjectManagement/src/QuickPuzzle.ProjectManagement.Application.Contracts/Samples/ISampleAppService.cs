using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace QuickPuzzle.ProjectManagement.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
