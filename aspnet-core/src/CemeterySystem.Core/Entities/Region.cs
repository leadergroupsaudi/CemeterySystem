using System;
using System.Collections.Generic;
using Abp.Domain.Entities;

namespace CemeterySystem.Entities
{
    public class Region : Entity, ISoftDelete
    {
        public Guid? Code { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsDeleted { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}
