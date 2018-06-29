using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HnbcInfo.Bbs.Bbs.BbsUsers.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Topics.Dtos
{
    [AutoMapFrom(typeof(Topic))]
    public class TopicDetailDto:EntityDto<long>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsTop { get; set; }

        public bool IsGood { get; set; }

        public int ViewCount { get; set; }

        public DateTime CreationTime { get; set; }

        public int ReplyCount { get; set; }

        public TopicAuthorDto Author { get; set; }


    }
}
