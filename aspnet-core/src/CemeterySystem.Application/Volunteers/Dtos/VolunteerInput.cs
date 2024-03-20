using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace CemeterySystem.Volunteers.Dto
{
    public class VolunteerInput : EntityDto<Guid>
    {
        public string Phone { get; set; }
        public string NameAr { get; set; }
        public int DistrictId { get; set; }
        public List<VolunteerOrderInput> VolunteerOrderInputs { get; set; }
    }


}
