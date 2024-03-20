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

        //public async Task<VolunteerInput> CreateVolunteer(VolunteerInput volunteer, bool isAcceptedTermsAndConditions)
        //{
        //    if (isAcceptedTermsAndConditions)
        //    {
        //        Volunteer volunteerEntity = new Volunteer()
        //        {
        //            Id = Guid.NewGuid(),
        //            Phone = volunteer.Phone,
        //            DistrictId = volunteer.DistrictId,
        //            NameAr = volunteer.NameAr
        //        };


        //        volunteerEntity.VolunteerOrders = volunteer.VolunteerOrderInputs.Select(volunteer => new VolunteerOrder
        //        {
        //            CemeteryId = volunteer.CemeratyId,
        //            VolunteerId = volunteerEntity.Id
        //        }).ToList();

        //        Guid volunteerId = await volunteerRepository.InsertAndGetIdAsync(volunteerEntity);
        //        volunteer.Id = volunteerId;
        //        return volunteer;
        //    }
        //    else
        //    {
        //        throw new UserFriendlyException("You must agree to the terms and conditions");
        //    }
        //}

        public async Task<VolunteerInput> CreateVolunteer(VolunteerInput volunteerInput, bool isAcceptedTermsAndConditions)
        {
            if (isAcceptedTermsAndConditions)
            {
                // Map VolunteerInput to Volunteer
                var volunteerEntity = ObjectMapper.Map<Volunteer>(volunteerInput);

                // Set VolunteerId for VolunteerOrders
                foreach (var volunteerOrder in volunteerEntity.VolunteerOrders)
                {
                    volunteerOrder.VolunteerId = volunteerEntity.Id;
                }

                // Insert the entity into the repository
                Guid volunteerId = await volunteerRepository.InsertAndGetIdAsync(volunteerEntity);
                volunteerInput.Id = volunteerId;

                return volunteerInput;
            }
            else
            {
                throw new UserFriendlyException("You must agree to the terms and conditions");
            }
        }

    }
}
