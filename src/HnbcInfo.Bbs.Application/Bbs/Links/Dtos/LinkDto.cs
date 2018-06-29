using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Links.Dtos
{
    [AutoMapFrom(typeof(Link))]
    public class LinkDto
    {
        public string Title { get; set; }

        public string Url { get; set; }

    }
}
