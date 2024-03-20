using System;
using Abp.Domain.Entities.Auditing;

namespace CemeterySystem.Entities
{
    public class Deceased : FullAuditedEntity<Guid>
    {
        public Guid? BurialId { get; set; }
        public Burial Burial { get; set; }                
        public Guid? PrayerPlaceId { get; set; }
        public PrayerPlace PrayerPlace { get; set; }      
        public Region Region { get; set; }                
        public int? RegionId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string UserIdentity { get; set; }
        public DateTime BurialDate { get; set; }
        public DateTime PrayerTime { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
    }
}
