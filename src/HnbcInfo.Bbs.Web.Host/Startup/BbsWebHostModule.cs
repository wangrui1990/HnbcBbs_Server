using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HnbcInfo.Bbs.Configuration;

namespace HnbcInfo.Bbs.Web.Host.Startup
{
    [DependsOn(
       typeof(BbsWebCoreModule))]
    public class BbsWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BbsWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BbsWebHostModule).GetAssembly());
        }
    }
}
