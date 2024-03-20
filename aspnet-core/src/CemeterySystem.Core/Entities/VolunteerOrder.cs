using System;
using Abp.Domain.Entities;

namespace CemeterySystem.Entities
{
    public class VolunteerOrder : ISoftDelete
    {
        public Guid CemeteryId { get; set; }
        public Cemetery Cemetery { get; set; } = null;
        public Guid VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string Notes { get; set; }
    }
}
