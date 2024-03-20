using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CemeterySystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CemeterySystem.EntityFrameworkCore.Config
{
    public class VolunteerOrderConfiguration : IEntityTypeConfiguration<VolunteerOrder>
    {
        public void Configure(EntityTypeBuilder<VolunteerOrder> builder)
        {
            builder.HasKey(x => new { x.CemeteryId, x.VolunteerId });

            builder.HasOne(volunteerOrder => volunteerOrder.Volunteer)
                   .WithMany(volunteer => volunteer.VolunteerOrders)
                   .HasForeignKey(volunteerOrder => volunteerOrder.VolunteerId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(volunteerOrder => volunteerOrder.Cemetery)
               .WithMany(cemetery => cemetery.VolunteerOrders)
               .HasForeignKey(volunteerOrder => volunteerOrder.CemeteryId)
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
