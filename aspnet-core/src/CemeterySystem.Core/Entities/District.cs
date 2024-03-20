using Abp.Domain.Entities;

namespace CemeterySystem.Entities
{
    public class District : Entity, ISoftDelete
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public bool IsDeleted { get; set; }
    }
}
