using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Topics.Dtos
{
    [AutoMapFrom(typeof(Topic))]
    public class MyCollectionTopicDto:EntityDto<long>
    {
        public string Title { get; set; }
        
        public DateTime CollectionTime { get; set; }

    }
}
