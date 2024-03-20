using System;
using Abp.Domain.Entities;

namespace CemeterySystem.Entities
{
    public class PrayerPlace : Entity<Guid>, ISoftDelete
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Facility { get; set; }
        public int Capacity { get; set; }
        public PlaceStatus Status { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public Guid CemeteryId { get; set; }
        public Cemetery Cemetery { get; set; }
        public bool IsDeleted { get; set; }
    }
}
