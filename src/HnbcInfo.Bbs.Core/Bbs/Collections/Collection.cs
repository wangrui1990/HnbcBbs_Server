using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Collections
{
    public class Collection : CreationAuditedEntity<long>
    {
        public virtual long TargetId { get; set; }

        ///<summary>
        ///切片、课程
        ///</summary>
        public virtual CollectionType Type { get; set; }
        
    }
}
