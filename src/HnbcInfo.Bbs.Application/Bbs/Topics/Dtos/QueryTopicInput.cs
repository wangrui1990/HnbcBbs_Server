using HnbcInfo.Bbs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Topics.Dtos
{
    public class QueryTopicInput: PagedInputDto
    {
        public long NodeId { get; set; }

    }
}
