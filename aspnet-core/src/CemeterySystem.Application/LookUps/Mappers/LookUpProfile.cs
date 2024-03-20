using AutoMapper;
using CemeterySystem.Entities;
using CemeterySystem.Volunteers.Dto;

namespace CemeterySystem.LookUps.Mappers
{
    public class LookUpProfile : Profile
    {
        public LookUpProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<Cemetery, CemeteryDto>().ReverseMap();
        }
    }
}
