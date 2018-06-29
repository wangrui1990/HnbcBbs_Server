using Abp.Web.Models;
using HnbcInfo.Bbs.Bbs.Replies;
using HnbcInfo.Bbs.Bbs.Replies.Dtos;
using HnbcInfo.Bbs.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs
{
    [Route("api/v1/reply")]
    public class ReplyController : BbsControllerBase
    {
        private readonly IReplyAppService _replyService;

        public ReplyController(
            IReplyAppService replyService)
        {
            _replyService = replyService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<AjaxResponse> GetReplies(GetRepliesInput input)
        {
            var output = await _replyService.GetReplies(input);
            return new AjaxResponse(output);
        }
    }
}
