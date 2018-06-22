using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using HnbcInfo.Bbs.Configuration;
using HnbcInfo.Bbs.Web;

namespace HnbcInfo.Bbs.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BbsDbContextFactory : IDesignTimeDbContextFactory<BbsDbContext>
    {
        public BbsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BbsDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BbsDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BbsConsts.ConnectionStringName));

            return new BbsDbContext(builder.Options);
        }
    }
}
