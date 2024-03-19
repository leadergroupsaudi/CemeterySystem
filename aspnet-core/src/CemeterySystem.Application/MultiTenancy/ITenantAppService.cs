using Abp.Application.Services;
using CemeterySystem.MultiTenancy.Dto;

namespace CemeterySystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

