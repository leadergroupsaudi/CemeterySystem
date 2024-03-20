using Abp.Domain.Repositories;
using CemeterySystem.Entities;
using CemeterySystem.Volunteers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CemeterySystem.Volunteers
{
    public class VolunteerAppService : CemeterySystemAppServiceBase, IVolunteerAppService
    {
        private readonly IRepository<Volunteer, Guid> volunteerRepository;

        public VolunteerAppService(IRepository<Volunteer, Guid> volunteerRepository)
        {
            this.volunteerRepository = volunteerRepository;
        }

        public Task<VolunteerInput> CreateVolunteer(VolunteerInput volunteer, bool termsAndConditions)
        {
            throw new NotImplementedException();
        }
    }
}
