using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Nodes
{
    public class Node : Entity<long>
    {
        public string Name { get; set; }

        public string Url { get; set; }

    }
}
