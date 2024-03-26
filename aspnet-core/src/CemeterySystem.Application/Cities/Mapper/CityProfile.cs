namespace CemeterySystem.Citys.Mapper
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CitiesDto>().ReverseMap();
        }
    }
}
