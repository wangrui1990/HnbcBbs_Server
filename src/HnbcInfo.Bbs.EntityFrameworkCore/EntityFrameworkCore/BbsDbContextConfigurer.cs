using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HnbcInfo.Bbs.EntityFrameworkCore
{
    public static class BbsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BbsDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BbsDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
