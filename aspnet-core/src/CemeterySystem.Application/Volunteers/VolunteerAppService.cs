using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
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

        public async Task<VolunteerInput> CreateVolunteer(VolunteerInput volunteer, bool isAcceptedTermsAndConditions)
        {
            if (isAcceptedTermsAndConditions)
            {
                Volunteer volunteerEntity = new Volunteer()
                {
                    Id = Guid.NewGuid(),
                    Phone = volunteer.Phone,
                    DistrictId = volunteer.DistrictId,
                    NameAr = volunteer.NameAr
                };

                // map VolunteerOrderInputs to VolunteerOrders
                volunteerEntity.VolunteerOrders = ObjectMapper.Map<List<VolunteerOrder>>(volunteer.VolunteerOrderInputs);
                volunteerEntity.VolunteerOrders.ForEach(order => order.VolunteerId = volunteerEntity.Id);

                Guid volunteerId = await volunteerRepository.InsertAndGetIdAsync(volunteerEntity);
                volunteer.Id = volunteerId;
                return volunteer;
            }
            else
            {
                throw new UserFriendlyException("You must agree to the terms and conditions");
            }
        }
    }

}
