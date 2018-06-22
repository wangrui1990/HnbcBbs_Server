using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HnbcInfo.Bbs.Authorization;

namespace HnbcInfo.Bbs
{
    [DependsOn(
        typeof(BbsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BbsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BbsAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BbsApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
