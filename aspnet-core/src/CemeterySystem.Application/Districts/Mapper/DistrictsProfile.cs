
namespace CemeterySystem.Districts.Mapper
{
    public class DistrictsProfile : Profile
    {
        public DistrictsProfile()
        {
            CreateMap<District, DistrictDto>().ReverseMap();
        }
    }
}
