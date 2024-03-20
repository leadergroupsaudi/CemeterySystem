using AutoMapper;
using CemeterySystem.Entities;
using CemeterySystem.Volunteers.Dto;

namespace CemeterySystem.Volunteers.Mappers
{
    public class VolunteerProfile : Profile
    {
        public VolunteerProfile()
        {
            CreateMap<VolunteerInput, Volunteer>().ReverseMap();
        }
    }
}
