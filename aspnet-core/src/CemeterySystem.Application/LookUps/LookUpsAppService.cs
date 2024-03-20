using Abp.Domain.Repositories;
using CemeterySystem.Entities;
using CemeterySystem.LookUps.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CemeterySystem.LookUps
{
    public class LookUpsAppService : CemeterySystemAppServiceBase, ILookUpsAppService
    {
        private readonly IRepository<Region> regionRepository;
        private readonly IRepository<City> cityRepository;
        private readonly IRepository<District> districtRepository;
        private readonly IRepository<Cemetery, Guid> cemeteryRepository;

        public LookUpsAppService(
            IRepository<Region> regionRepository,
            IRepository<City> cityRepository,
            IRepository<District> districtRepository,
            IRepository<Cemetery, Guid> cemeteryRepository)
        {
            this.regionRepository = regionRepository;
            this.cityRepository = cityRepository;
            this.districtRepository = districtRepository;
            this.cemeteryRepository = cemeteryRepository;
        }
        public async Task<List<RegionDto>> GetRegions()
        {
            var query = await regionRepository.GetAll().ToListAsync();
            var result = ObjectMapper.Map<List<RegionDto>>(query);
            return result;
        }

        public async Task<List<CityDto>> GetCities(int regionId)
        {
            var query = await cityRepository.GetAll().Where(city => city.RegionId == regionId).ToListAsync();
            var result = ObjectMapper.Map<List<CityDto>>(query);
            return result;
        }

        public async Task<List<DistrictDto>> GetDistricts(int cityId)
        {
            var query = await districtRepository.GetAll().Where(district => district.CityId == cityId).ToListAsync();
            var result = ObjectMapper.Map<List<DistrictDto>>(query);
            return result;
        }

        public async Task<List<CemeteryDto>> GetCemeteries(int cityId)
        {
            var query = await cemeteryRepository.GetAll().Where(cemetery => cemetery.CityId == cityId).ToListAsync();
            var result = ObjectMapper.Map<List<CemeteryDto>>(query);
            return result;
        }
    }
}
