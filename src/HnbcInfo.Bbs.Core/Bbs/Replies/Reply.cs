using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Replies
{
    public class Reply : CreationAuditedEntity<long>
    {
        public const int MaxContentLength = 2048;

        public long TopicId { get; set; }

        [StringLength(MaxContentLength)]
        public string Content { get; set; }
    }
}
