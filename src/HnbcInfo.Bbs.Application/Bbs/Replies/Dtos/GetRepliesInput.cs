using HnbcInfo.Bbs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Replies.Dtos
{
    public class GetRepliesInput: PagedInputDto
    {
        public long TopicId { get; set; }

    }
}
