using System.Threading.Tasks;
using Abp.Application.Services;
using CemeterySystem.Sessions.Dto;

namespace CemeterySystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
