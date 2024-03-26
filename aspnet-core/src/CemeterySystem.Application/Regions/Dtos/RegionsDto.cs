namespace CemeterySystem.Regions.Dtos
{
    public class RegionsDto : EntityDto<int?>
    {
        [Required]
        public string NameAr { get; set; }
    }
}
