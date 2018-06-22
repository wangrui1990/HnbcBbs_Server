using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Likes
{
    public class Like : CreationAuditedEntity<long>
    {
        public virtual long TargetId { get; set; }
        
        public virtual LikeType Type { get; set; }
    }
}
