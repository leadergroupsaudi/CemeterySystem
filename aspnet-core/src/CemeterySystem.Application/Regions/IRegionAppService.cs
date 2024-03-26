
namespace CemeterySystem.Regions
{
    public interface IRegionAppService
    {
        Task<List<RegionDto>> GetAll();
        Task<RegionDto> GetById(int input);
        Task<Region> Create(RegionsDto input);
        Task<Region> Update(RegionsDto input);
        Task Delete(int input);
    }
}
