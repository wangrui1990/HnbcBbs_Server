using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Bonuses
{
    public class Bonus:Entity<long>
    {
        /// <summary>
        /// Max length of the <see cref="Description"/> property.
        /// </summary>
        public const int MaxDescriptionLength = 128;

        public virtual long UserId { get; set; }

        public virtual int Points { get; set; }

        public virtual BonusType Type { get; set; }

        [StringLength(MaxDescriptionLength)]
        public virtual string Description { get; set; }
    }
}
