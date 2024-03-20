using System;
using Abp.Domain.Entities;

namespace CemeterySystem.Entities
{
    public class Address : Entity<Guid>, ISoftDelete
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsDeleted { get; set; }
        ///////
    }
}
