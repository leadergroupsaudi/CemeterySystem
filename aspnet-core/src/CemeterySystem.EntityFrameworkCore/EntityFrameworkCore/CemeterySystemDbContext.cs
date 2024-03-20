using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CemeterySystem.Authorization.Roles;
using CemeterySystem.Authorization.Users;
using CemeterySystem.MultiTenancy;
using CemeterySystem.Entities;

namespace CemeterySystem.EntityFrameworkCore
{
    public class CemeterySystemDbContext : AbpZeroDbContext<Tenant, Role, User, CemeterySystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        #region DbSets 
        public DbSet<Address> Address => Set<Address>();
        public DbSet<Burial> Burials => Set<Burial>();
        public DbSet<Cemetery> Cemeteries => Set<Cemetery>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Deceased> Deceaseds => Set<Deceased>();
        public DbSet<District> Districts => Set<District>();
        public DbSet<PrayerPlace> PrayerPlaces => Set<PrayerPlace>();
        public DbSet<Region> Regions => Set<Region>();
        public DbSet<Volunteer> Volunteers => Set<Volunteer>();
        public DbSet<Volunteer> VolunteerOrders => Set<Volunteer>();

        #endregion

        public CemeterySystemDbContext(DbContextOptions<CemeterySystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CemeterySystemDbContext).Assembly);
        }
    }
}
