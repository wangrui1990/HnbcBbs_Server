using Abp.Application.Services;
using HnbcInfo.Bbs.Bbs.Topics.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs.Topics
{
    public interface ITopicAppService : IApplicationService
    {
        Task<ICollection<TopicDto>> GetTopTopics();
    }
}
