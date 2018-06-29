using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Ads
{
    public class Ad : Entity<long>
    {
        public string Name { get; set; }

        public string Html { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }

        public AdType Type { get; set; }

    }
}
