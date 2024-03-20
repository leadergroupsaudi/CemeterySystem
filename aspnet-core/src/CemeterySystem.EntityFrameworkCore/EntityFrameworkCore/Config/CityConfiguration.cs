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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(city => city.Id);
            builder.HasMany(city => city.Districts)
                    .WithOne(district => district.City)
                    .HasForeignKey(district => district.CityId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(city => city.Cemeteries)
                    .WithOne(cemetery => cemetery.City)
                    .HasForeignKey(cemetery => cemetery.CityId)
                    .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder.HasData(SeedData.LoadCities());
        }
    }
}
