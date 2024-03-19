using System.Threading.Tasks;
using Abp.Application.Services;
using CemeterySystem.Authorization.Accounts.Dto;

namespace CemeterySystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
