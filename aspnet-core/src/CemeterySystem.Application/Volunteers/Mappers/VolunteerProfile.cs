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
            .ForMember(dest => dest.CemeteryId, opt => opt.MapFrom(src => src.CemeratyId))
            .ForMember(dest => dest.VolunteerId, opt => opt.Ignore());

            CreateMap<VolunteerInput, Volunteer>();
        }
    }
}
