using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using static Castle.MicroKernel.ModelBuilder.Descriptors.InterceptorDescriptor;

namespace CemeterySystem.Entities
{
    public class Cemetery : Entity<Guid>, ISoftDelete
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
        public int? DistrictId { get; set; }  
        public District District { get; set; }

        public string Phone { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public PlaceStatus Status { get; set; }
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
        public bool IsDeleted { get; set; }
        public List<VolunteerOrder> VolunteerOrders { get; set; } = new List<VolunteerOrder>();
        public List<Burial> Burials { get; set; } = new List<Burial>();
        public List<PrayerPlace> PrayerPlaces { get; set; } = new List<PrayerPlace>();
    }
}
