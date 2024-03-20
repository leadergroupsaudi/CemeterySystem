using Abp.Domain.Repositories;
using CemeterySystem.Entities;
using CemeterySystem.Volunteers.Dto;
using System;
using System.Collections.Generic;
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
        public Task<List<CemeteryDto>> GetCemeteries(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<CityDto>> GetCities(int regionId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DistrictDto>> GetDistricts(int cityId)
        {
            throw new NotImplementedException();
        }

        public Task<List<RegionDto>> GetRegions()
        {
            throw new NotImplementedException();
        }
    }
}
