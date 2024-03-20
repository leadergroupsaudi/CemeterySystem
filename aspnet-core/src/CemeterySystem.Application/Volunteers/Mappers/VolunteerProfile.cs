using AutoMapper;
using CemeterySystem.Entities;
using CemeterySystem.Volunteers.Dto;
using System;

namespace CemeterySystem.Volunteers.Mappers
{
    public class VolunteerProfile : Profile
    {
        public VolunteerProfile()
        {
            CreateMap<VolunteerOrderInput, VolunteerOrder>()
            .ForMember(x => x.CemeteryId, opt => opt.MapFrom(y => y.CemeratyId))
            .ForMember(z => z.VolunteerId, opt => opt.Ignore());

            CreateMap<VolunteerInput, Volunteer>();
        }
    }
}
