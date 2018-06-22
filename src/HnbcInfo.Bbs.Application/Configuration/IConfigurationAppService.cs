using System.Threading.Tasks;
using HnbcInfo.Bbs.Configuration.Dto;

namespace HnbcInfo.Bbs.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
