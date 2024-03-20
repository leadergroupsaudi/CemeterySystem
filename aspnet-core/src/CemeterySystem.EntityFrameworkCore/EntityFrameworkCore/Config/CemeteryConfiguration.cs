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
    public class CemeteryConfiguration : IEntityTypeConfiguration<Cemetery>
    {
        public void Configure(EntityTypeBuilder<Cemetery> builder)
        {
            builder.HasKey(cemetery => cemetery.Id);


            builder.HasMany(cemetery => cemetery.Burials)
                    .WithOne(burial => burial.Cemetery)
                    .HasForeignKey(burial => burial.CemeteryId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(cemetery => cemetery.PrayerPlaces)
                    .WithOne(prayerPlace => prayerPlace.Cemetery)
                    .HasForeignKey(prayerPlace => prayerPlace.CemeteryId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(SeedData.LoadCemerties());
        }
    }
}
