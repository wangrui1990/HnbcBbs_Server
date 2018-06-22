using System.Collections.Generic;

namespace HnbcInfo.Bbs.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
