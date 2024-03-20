using CemeterySystem.LookUps.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CemeterySystem.LookUps
{
    public interface ILookUpsAppService
    {
        Task<List<RegionDto>> GetRegions();
        Task<List<CityDto>> GetCities(int regionId);
        Task<List<DistrictDto>> GetDistricts(int cityId);
        Task<List<CemeteryDto>> GetCemeteries(int cityId);
    }
}
