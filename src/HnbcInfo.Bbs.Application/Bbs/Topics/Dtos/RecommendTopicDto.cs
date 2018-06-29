﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Topics.Dtos
{
    [AutoMapFrom(typeof(Topic))]
    public class RecommendTopicDto : EntityDto<long>
    {
        public string Title { get; set; }
    }
}
