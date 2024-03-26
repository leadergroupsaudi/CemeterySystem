

//namespace CemeterySystem.Districts
//{
//    public class DistrictsAppService : CemeterySystemAppServiceBase, IDistrictsAppService
//    {
//        private readonly IRepository<District> _districtRepository;

//        public DistrictsAppService(IRepository<District> districtRepository)
//        {
//            _districtRepository = districtRepository;
//        }

//        public async Task<List<RegionDto>> GetAll()
//        {
//            try
//            {
//                var districts = await _districtRepository.GetAll().ToListAsync();
//                var result = ObjectMapper.Map<List<DistrictsDto>>(districts);
//                return result;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("", ex);
//            }
//        }

//        public async Task<RegionDto> GetById(int input)
//        {
//            try
//            {
//                var regionId = await _regionRepository.GetAsync(input);
//                var result = ObjectMapper.Map<RegionDto>(regionId);
//                return result;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("", ex);
//            }
//        }

//        public async Task<Region> Create(RegionsDto input)
//        {
//            try
//            {
//                var existingRegion = await _regionRepository.FirstOrDefaultAsync(r => r.NameAr == input.NameAr);
//                if (existingRegion != null)
//                {
//                    throw new Exception();
//                }
//                var entity = ObjectMapper.Map<Region>(input);
//                var entityId = await _regionRepository.InsertAndGetIdAsync(entity);
//                return entity;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("", ex);
//            }
//        }

//        public async Task<Region> Update(RegionsDto input)
//        {
//            try
//            {
//                var entity = await _regionRepository.GetAsync(input.Id);
//                ObjectMapper.Map(input, entity);
//                await _regionRepository.UpdateAsync(entity);
//                return ObjectMapper.Map<Region>(entity);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("", ex);
//            }
//        }

//        public async Task Delete(int input)
//        {
//            if (input <= 0)
//            {
//                throw new ArgumentException();
//            }
//            var existingRegion = await _regionRepository.GetAsync(input);
//            if (existingRegion == null)
//            {
//                throw new KeyNotFoundException();
//            }
//            try
//            {
//                await _regionRepository.DeleteAsync(input);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("", ex);
//            }
//        }
//    }
//}
