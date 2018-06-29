using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Links
{
    public class Link : Entity<long>
    {
        public string Title { get; set; }

        public string Url { get; set; }
        
        public int Order { get; set; }

    }
}
