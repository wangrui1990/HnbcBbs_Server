using Abp.Web.Models;
using HnbcInfo.Bbs.Bbs.Ads;
using HnbcInfo.Bbs.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs
{
    [Route("api/v1/ad")]
    public class AdController : BbsControllerBase
    {
        private readonly IAdAppService _adService;

        public AdController(
            IAdAppService adService)
        {
            _adService = adService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("side")]
        public async Task<AjaxResponse> GetSideAd(long nodeId)
        {
            var output = await _adService.GetSideAd(nodeId);
            return new AjaxResponse(output);
        }
    }
}
