
namespace CemeterySystem.Citys.Dtos
{
    public class CitiesDto : EntityDto<int?>
    {
        [Required]
        public string NameAr { get; set; }
        public int RegionId { get; set; }

    }
}
