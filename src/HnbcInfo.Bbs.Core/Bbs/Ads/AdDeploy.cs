using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Ads
{
    public class AdDeploy:Entity<long>
    {
        /// <summary>
        /// DeployType为NodeSide时，设置节点特有广告使用，为空表示可在任意节点显示
        /// </summary>
        public long? TargetId { get; set; }

        public long AdId { get; set; }

        public AdDeployType DeployType { get; set; }
    }
}
