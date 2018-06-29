using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HnbcInfo.Bbs.Bbs.Topics.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Replies.Dtos
{
    [AutoMapFrom(typeof(Reply))]
    public class ReplyDto:EntityDto<long>
    {
        public DateTime CreationTime { get; set; }

        public int LikeCount { get; set; }
        
        public string Content { get; set; }

        public TopicAuthorDto Author { get; set; }

    }
}
