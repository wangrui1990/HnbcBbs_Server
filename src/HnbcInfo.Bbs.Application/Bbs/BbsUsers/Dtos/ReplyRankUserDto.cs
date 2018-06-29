using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HnbcInfo.Bbs.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.BbsUsers.Dtos
{
    [AutoMapFrom(typeof(User))]
    public class ReplyRankUserDto:EntityDto<long>
    {
        public string Name { get; set; }

        public string Avatar { get; set; }

        public int ReplyCount { get; set; }

    }
}
