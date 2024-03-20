using System;
using Abp.Domain.Entities.Auditing;

namespace CemeterySystem.Entities
{
    public class Burial : FullAuditedEntity<Guid>
    {
        public Guid CemeteryId { get; set; }
        public Cemetery Cemetery { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public PlaceStatus Status { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

    }
}

