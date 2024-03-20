using System;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;

namespace CemeterySystem.Entities
{
    public class Volunteer : FullAuditedEntity<Guid>
    {
        public string Phone { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? DistrictId { get; set; }
        public District District { get; set; }
        public VolunteerStatus Status { get; set; }
        public List<VolunteerOrder> VolunteerOrders { get; set; } = new List<VolunteerOrder>();
    }
}
