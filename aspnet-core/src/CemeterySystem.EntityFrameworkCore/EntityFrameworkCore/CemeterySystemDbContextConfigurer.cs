using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CemeterySystem.EntityFrameworkCore
{
    public static class CemeterySystemDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CemeterySystemDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CemeterySystemDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
