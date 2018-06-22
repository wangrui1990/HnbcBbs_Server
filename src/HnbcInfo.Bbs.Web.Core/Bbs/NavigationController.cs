using Abp.Web.Models;
using HnbcInfo.Bbs.Bbs.Nodes;
using HnbcInfo.Bbs.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs
{
    [Route("api/v1/navigation")]
    public class NavigationController : BbsControllerBase
    {
        private readonly INodeAppService _nodeService;

        public NavigationController(
            INodeAppService nodeService)
        {
            _nodeService = nodeService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<AjaxResponse> GetRecommendBanners()
        {
            var output = await _nodeService.GetNavigations();
            return new AjaxResponse(output);
        }
    }
}
