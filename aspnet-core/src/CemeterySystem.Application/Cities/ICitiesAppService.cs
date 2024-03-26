
namespace CemeterySystem.Citys
{
    public interface ICitiesAppService
    {
        Task<List<CitiesDto>> GetAll();
        Task<CitiesDto> GetById(int input);
        Task<City> Create(CitiesDto input);

        Task<City> Update(CitiesDto input);
        Task Delete(int input);
    }
}
