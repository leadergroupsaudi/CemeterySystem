using Abp.Domain.Repositories;
using Abp.UI;
using CemeterySystem.Entities;
using CemeterySystem.Volunteers.Dto;
using System;
using System.Collections.Generic;
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
            await CheckPhoneNumberExists(volunteer.Phone);

            if (isAcceptedTermsAndConditions)
            {
                await ValidateVolunteerInput(volunteer);

                var volunteerEntity = MapVolunteerInputToEntity(volunteer);
                volunteerEntity.VolunteerOrders = MapVolunteerOrderInputsToEntities(volunteer.VolunteerOrderInputs);

                Guid volunteerId = await InsertVolunteerAsync(volunteerEntity);
                volunteer.Id = volunteerId;
                return volunteer;
            }
            else
            {
                throw new UserFriendlyException(L("YouMustAgreeToTheTermsAndConditions"));
            }
        }

        private async Task CheckPhoneNumberExists(string phoneNumber)
        {
            var phoneNumberExists = await volunteerRepository.FirstOrDefaultAsync(v => v.Phone == phoneNumber);
            if (phoneNumberExists != null)
            {
                throw new UserFriendlyException(L("VolunteerAlreadyAdded"));
            }
        }

        private async Task ValidateVolunteerInput(VolunteerInput volunteer)
        {
            if (volunteer.NameAr == null)
            {
                throw new UserFriendlyException(L("VolunteerNameRequired"));
            }
            if (volunteer.Phone is null)
            {
                throw new UserFriendlyException(L("PhoneNumberRequired"));
            }
        }

        private Volunteer MapVolunteerInputToEntity(VolunteerInput volunteer)
        {
            return ObjectMapper.Map<Volunteer>(volunteer);
        }

        private List<VolunteerOrder> MapVolunteerOrderInputsToEntities(List<VolunteerOrderInput> volunteerOrderInputs)
        {
            return ObjectMapper.Map<List<VolunteerOrder>>(volunteerOrderInputs);
        }

        private async Task<Guid> InsertVolunteerAsync(Volunteer volunteerEntity)
        {
            return await volunteerRepository.InsertAndGetIdAsync(volunteerEntity);
        }
    }

}
