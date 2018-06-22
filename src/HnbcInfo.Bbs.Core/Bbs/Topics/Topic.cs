using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Topics
{
    public class Topic : CreationAuditedEntity<long>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsTop { get; set; }

        public bool IsGood { get; set; }

        public int ViewCount { get; set; }

        public long NodeId { get; set; }

    }
}
