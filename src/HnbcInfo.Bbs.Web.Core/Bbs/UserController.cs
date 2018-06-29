using Abp.Web.Models;
using HnbcInfo.Bbs.Bbs.BbsUsers;
using HnbcInfo.Bbs.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs
{
    [Route("api/v1/bbsuser")]
    public class UserController : BbsControllerBase
    {
        private readonly IBbsUserAppService _userService;

        public UserController(
            IBbsUserAppService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("rank")]
        public async Task<AjaxResponse> GetRankUsers()
        {
            var output = await _userService.GetReplyRank();
            return new AjaxResponse(output);
        }

        [HttpGet]
        [Route("info/{id}")]
        public async Task<AjaxResponse> GetUserInfo(long id)
        {
            var output = await _userService.GetUserInfo(id);
            return new AjaxResponse(output);
        }

        [HttpGet]
        [Route("baseinfo")]
        public async Task<AjaxResponse> GetMyBaseInfo()
        {
            var output = await _userService.GetMyBaseInfo();
            return new AjaxResponse(output);
        }
    }
}
