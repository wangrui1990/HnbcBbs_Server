using Abp.Web.Models;
using HnbcInfo.Bbs.Bbs.Topics;
using HnbcInfo.Bbs.Bbs.Topics.Dtos;
using HnbcInfo.Bbs.Controllers;
using HnbcInfo.Bbs.Dtos;
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
        public async Task<AjaxResponse> GetTopTopics()
        {
            var output = await _topicService.GetTopTopics();
            return new AjaxResponse(output);
        }

        [HttpGet]
        [Route("")]
        public async Task<AjaxResponse> GetTopics(QueryTopicInput input)
        {
            var output = await _topicService.GetTopics(input);
            return new AjaxResponse(output);
        }

        [HttpGet]
        [Route("recommend")]
        public async Task<AjaxResponse> GetRecommendTopics()
        {
            var output = await _topicService.GetRecommendTopics();
            return new AjaxResponse(output);
        }

        [HttpGet]
        [Route("hot")]
        public async Task<AjaxResponse> GetHotTopics()
        {
            var output = await _topicService.GetHotTopics();
            return new AjaxResponse(output);
        }

        [HttpGet]
        [Route("detail")]
        public async Task<AjaxResponse> GetTopicDetail(long id)
        {
            var output = await _topicService.GetTopicDetail(id);
            return new AjaxResponse(output);
        }

        [HttpGet]
        [Route("my")]
        public async Task<AjaxResponse> GetMyTopics(PagedInputDto input)
        {
            var output = await _topicService.GetMyTopics(input);
            return new AjaxResponse(output);
        }
        [HttpGet]
        [Route("mycollection")]
        public async Task<AjaxResponse> GetMyCollectionTopics(PagedInputDto input)
        {
            var output = await _topicService.GetMyCollectionTopics(input);
            return new AjaxResponse(output);
        }
    }
}
