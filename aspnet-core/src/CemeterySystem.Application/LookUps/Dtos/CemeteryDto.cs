using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace CemeterySystem.Volunteers.Dto
{
    public class CemeteryDto : EntityDto<Guid>
    {
        public string NameAr { get; set; } //
    }
}
