using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HnbcInfo.Bbs.Bbs.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Topics.Dtos
{
    [AutoMapFrom(typeof(Node))]
    public class Node4TopicDto:EntityDto<long>
    {
        public string Name { get; set; }

    }
}
