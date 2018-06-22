using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Topics.Dtos
{
    [AutoMapFrom(typeof(Topic))]
    public class TopicDto:EntityDto<long>
    {
        public string Title { get; set; }
        
        public bool IsTop { get; set; }

        public bool IsGood { get; set; }

        public DateTime CreationTime { get; set; }

        public int LikeCount { get; set; }

        public int ReplyCount { get; set; }
        
        public TopicAuthorDto Author { get; set; }

        public Node4TopicDto Node { get; set; }

    }
}
