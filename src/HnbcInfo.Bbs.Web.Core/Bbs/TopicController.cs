using Abp.Web.Models;
using HnbcInfo.Bbs.Bbs.Topics;
using HnbcInfo.Bbs.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs
{
    [Route("api/v1/topic")]
    public class TopicController : BbsControllerBase
    {
        private readonly ITopicAppService _topicService;

        public TopicController(
            ITopicAppService topicService)
        {
            _topicService = topicService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("top")]
        public async Task<AjaxResponse> GetRecommendBanners()
        {
            var output = await _topicService.GetTopTopics();
            return new AjaxResponse(output);
        }
    }
}
