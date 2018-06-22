using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Nodes.Dtos
{
    [AutoMapFrom(typeof(Node))]
    public class NodeNavigationDto
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public bool IsNew { get; set; }

    }
}
