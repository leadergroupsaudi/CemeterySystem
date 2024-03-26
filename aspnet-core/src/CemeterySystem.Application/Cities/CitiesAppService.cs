
using Abp.UI;

namespace CemeterySystem.Citys
{
    public class CitiesAppService : CemeterySystemAppServiceBase, ICitiesAppService
    {
        private readonly IRepository<City> _cityRepository;

        public CitiesAppService(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<CitiesDto>> GetAll()
        {
            try
            {
                var regions = await _cityRepository.GetAll().ToListAsync();
                var result = ObjectMapper.Map<List<CitiesDto>>(regions);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task<CitiesDto> GetById(int input)
        {
            try
            {
                var regionId = await _cityRepository.GetAsync(input);
                var result = ObjectMapper.Map<CitiesDto>(regionId);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task<City> Create(CitiesDto input)
        {
            try
            {
                var existingCity = await _cityRepository.FirstOrDefaultAsync(c => c.NameAr == input.NameAr);
                if (existingCity == null)
                {
                    var entity = ObjectMapper.Map<City>(input);
                    var entityId = await _cityRepository.InsertAndGetIdAsync(entity);
                    return entity;
                }
                else
                {
                    throw new UserFriendlyException();
                }
                
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException();
            }
        }

        public async Task<City> Update(CitiesDto input)
        {
            try
            {
                var entity = await _cityRepository.GetAsync(input.Id.Value);
                ObjectMapper.Map(input, entity);
                await _cityRepository.UpdateAsync(entity);
                return ObjectMapper.Map<City>(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public async Task Delete(int input)
        {
            if (input <= 0)
            {
                throw new ArgumentException();
            }
            var existingCity = await _cityRepository.GetAsync(input);
            if (existingCity == null)
            {
                throw new KeyNotFoundException();
            }
            try
            {
                await _cityRepository.DeleteAsync(input);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }
    }
}
