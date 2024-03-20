using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CemeterySystem.Entities;
using CemeterySystem.EntityFrameworkCore.Seed.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CemeterySystem.EntityFrameworkCore.Config
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(district => district.Id);

            builder.HasData(SeedData.LoadDistricts());
        }
    }
}
