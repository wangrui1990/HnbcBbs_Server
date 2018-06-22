using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using HnbcInfo.Bbs.Configuration.Dto;

namespace HnbcInfo.Bbs.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BbsAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
