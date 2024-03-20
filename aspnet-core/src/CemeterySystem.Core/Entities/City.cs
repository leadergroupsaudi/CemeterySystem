using System.Collections.Generic;
using Abp.Domain.Entities;

namespace CemeterySystem.Entities
{
    public class City : Entity, ISoftDelete
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public List<District> Districts { get; set; } = new List<District>();
        public List<Cemetery> Cemeteries { get; set; } = new List<Cemetery>();
        public bool IsDeleted { get; set; }
    }
}
