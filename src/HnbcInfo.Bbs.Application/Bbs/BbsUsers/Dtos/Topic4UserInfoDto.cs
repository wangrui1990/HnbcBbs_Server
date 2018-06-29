using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HnbcInfo.Bbs.Bbs.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.BbsUsers.Dtos
{
    [AutoMapFrom(typeof(Topic))]
    public class Topic4UserInfoDto : EntityDto<long>
    {
        public string Title { get; set; }

        public bool IsTop { get; set; }

        public bool IsGood { get; set; }

        public DateTime CreationTime { get; set; }
        
        public int ViewCount { get; set; }

        public int ReplyCount { get; set; }
        
    }
}
