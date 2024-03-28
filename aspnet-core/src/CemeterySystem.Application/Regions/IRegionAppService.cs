
namespace CemeterySystem.Regions
{
    public interface IRegionAppService
    {
        public Task<PagedResultDto<RegionDto>> GetRegion(GetRegionDto input);
        public Task<RegionDto> GetById(int input);
        public Task<Region> Create(RegionsDto input);
        public Task<Region> Update(RegionsDto input);
        public Task Delete(int input);
    }
}
