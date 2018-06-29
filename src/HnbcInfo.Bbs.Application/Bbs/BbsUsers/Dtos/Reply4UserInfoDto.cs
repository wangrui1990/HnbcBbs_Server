using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HnbcInfo.Bbs.Bbs.Replies;
using HnbcInfo.Bbs.Bbs.Topics;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.BbsUsers.Dtos
{
    [AutoMapFrom(typeof(Reply))]
    public class Reply4UserInfoDto : EntityDto<long>
    {
        public DateTime CreationTime { get; set; }
        
        public string Content { get; set; }

        public Topic4ReplyDto Topic { get; set; }

    }

    [AutoMapFrom(typeof(Topic))]
    public class Topic4ReplyDto:EntityDto<long>
    {
        public string Title { get; set; }
    }
}
