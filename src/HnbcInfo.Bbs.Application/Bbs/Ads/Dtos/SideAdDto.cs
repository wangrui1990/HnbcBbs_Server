using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Ads.Dtos
{
    [AutoMapFrom(typeof(Ad))]
    public class SideAdDto
    {
        public string Title { get; set; }

        public string Html { get; set; }

    }
}
