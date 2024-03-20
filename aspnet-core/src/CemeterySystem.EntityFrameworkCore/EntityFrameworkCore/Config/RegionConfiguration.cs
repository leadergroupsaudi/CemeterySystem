using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityHistory;
using CemeterySystem.Entities;
using CemeterySystem.EntityFrameworkCore.Seed.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CemeterySystem.EntityFrameworkCore.Config
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(region => region.Id);
            builder.HasMany(region => region.Cities)
                .WithOne(city => city.Region)
                .HasForeignKey(city => city.RegionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(SeedData.LoadRegions());
        }
    }
}
