using CemeterySystem.Dto;

namespace CemeterySystem.Regions.Dtos
{
    public class GetRegionDto : PagedAndSortedInputDto
    {
        public string Filter { get; set; }
    }
}
