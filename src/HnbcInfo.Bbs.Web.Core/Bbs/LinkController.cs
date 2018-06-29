using Abp.Web.Models;
using HnbcInfo.Bbs.Bbs.Links;
using HnbcInfo.Bbs.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs
{
    [Route("api/v1/link")]
    public class LinkController : BbsControllerBase
    {
        private readonly ILinkAppService _linkService;

        public LinkController(
            ILinkAppService linkService)
        {
            _linkService = linkService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<AjaxResponse> GetSideAd()
        {
            var output = await _linkService.GetLinks();
            return new AjaxResponse(output);
        }
    }
}
