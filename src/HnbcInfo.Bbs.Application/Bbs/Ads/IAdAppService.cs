using Abp.Application.Services;
using HnbcInfo.Bbs.Bbs.Ads.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs.Ads
{
    public interface IAdAppService : IApplicationService
    {
        Task<SideAdDto> GetSideAd(long nodeId);
    }
}
