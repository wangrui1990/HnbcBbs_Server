using Abp.Application.Services;
using HnbcInfo.Bbs.Bbs.Topics.Dtos;
using HnbcInfo.Bbs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs.Topics
{
    public interface ITopicAppService : IApplicationService
    {
        Task<ICollection<TopicDto>> GetTopTopics();

        Task<PagedResultAndCountOutput<TopicDto>> GetTopics(QueryTopicInput input);

        Task<ICollection<RecommendTopicDto>> GetRecommendTopics();

        Task<ICollection<HotTopicDto>> GetHotTopics();

        Task<TopicDetailDto> GetTopicDetail(long id);

        Task<PagedResultAndCountOutput<MyTopicDto>> GetMyTopics(PagedInputDto input);

        Task<PagedResultAndCountOutput<MyCollectionTopicDto>> GetMyCollectionTopics(PagedInputDto input);

    }
}
