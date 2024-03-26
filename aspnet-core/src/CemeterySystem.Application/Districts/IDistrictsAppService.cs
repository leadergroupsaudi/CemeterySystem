
namespace CemeterySystem.Districts
{
    public interface IDistrictsAppService
    {
        Task<List<DistrictsDto>> GetAll();
        Task<DistrictsDto> GetById(int input);
        Task<District> Create(DistrictsDto input);
        Task<District> Update(DistrictsDto input);
        Task Delete(int input);
    }
}
