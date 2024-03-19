using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CemeterySystem.Authorization.Roles;
using CemeterySystem.Authorization.Users;
using CemeterySystem.MultiTenancy;

namespace CemeterySystem.EntityFrameworkCore
{
    public class CemeterySystemDbContext : AbpZeroDbContext<Tenant, Role, User, CemeterySystemDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CemeterySystemDbContext(DbContextOptions<CemeterySystemDbContext> options)
            : base(options)
        {
        }
    }
}
