namespace CemeterySystem.Regions.Mapper
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionsDto>().ReverseMap();
        }
    }
}
