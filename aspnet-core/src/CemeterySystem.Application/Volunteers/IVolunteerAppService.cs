using CemeterySystem.Volunteers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CemeterySystem.Volunteers
{
    public interface IVolunteerAppService
    {
        Task<VolunteerInput> CreateVolunteer(VolunteerInput volunteer, bool termsAndConditions);
    }
}
