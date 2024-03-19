using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CemeterySystem.MultiTenancy;

namespace CemeterySystem.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
