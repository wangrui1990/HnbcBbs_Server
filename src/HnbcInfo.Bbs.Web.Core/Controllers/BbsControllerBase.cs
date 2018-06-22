using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace HnbcInfo.Bbs.Controllers
{
    public abstract class BbsControllerBase: AbpController
    {
        protected BbsControllerBase()
        {
            LocalizationSourceName = BbsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
