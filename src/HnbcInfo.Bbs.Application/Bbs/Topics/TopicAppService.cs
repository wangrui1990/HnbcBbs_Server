using Abp.Domain.Repositories;
using HnbcInfo.Bbs.Bbs.Nodes;
using System;
using System.Collections.Generic;
using System.Text;
using HnbcInfo.Bbs.Bbs.Topics.Dtos;
using System.Threading.Tasks;
using HnbcInfo.Bbs.Bbs.Likes;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.AutoMapper;
using HnbcInfo.Bbs.Bbs.Replies;
using HnbcInfo.Bbs.Dtos;
using Abp.Linq.Extensions;
using Abp.UI;
using HnbcInfo.Bbs.Bbs.BbsUsers.Dtos;
using Abp.Runtime.Session;
using HnbcInfo.Bbs.Bbs.Collections;

namespace HnbcInfo.Bbs.Bbs.Topics
{
    public class TopicAppService : BbsAppServiceBase, ITopicAppService
    {
        private readonly IRepository<Node, long> _nodeRepository;
        private readonly IRepository<Topic, long> _topicRepository;
        private readonly IRepository<Like, long> _likeRepository;
        private readonly IRepository<Reply, long> _replyRepository;
        private readonly IRepository<Collection, long> _collectionRepository;

        public TopicAppService(IRepository<Node, long> nodeRepository,
            IRepository<Topic, long> topicRepository,
            IRepository<Like, long> likeRepository,
            IRepository<Reply, long> replyRepository,
            IRepository<Collection, long> collectionRepository)
        {
            _nodeRepository = nodeRepository;
            _topicRepository = topicRepository;
            _likeRepository = likeRepository;
            _replyRepository = replyRepository;
            _collectionRepository = collectionRepository;
        }

        public async Task<PagedResultAndCountOutput<TopicDto>> GetTopics(QueryTopicInput input)
        {
            var query = from t in _topicRepository.GetAll()
                        join u in UserManager.Users
                        on t.CreatorUserId equals u.Id

                        join n in _nodeRepository.GetAll()
                        on t.NodeId equals n.Id

                        join l in _likeRepository.GetAll()
                        on new { tid = t.Id, type = LikeType.Topic }
                            equals new { tid = l.TargetId, type = l.Type }
                        into likes

                        join r in _replyRepository.GetAll()
                        on t.Id equals r.TopicId
                        into replies

                        join lr in _replyRepository.GetAll()
                        on t.Id equals lr.TopicId
                        into allreply

                        from lastreply in allreply.OrderByDescending(o=>o.CreationTime).DefaultIfEmpty()

                        where t.NodeId == input.NodeId

                        select new { t,
                            u,
                            n,
                            likes,
                            replies ,
                            latesttime = lastreply==null?t.CreationTime:lastreply.CreationTime,
                            latestreplytime = lastreply == null ? null : (DateTime?)lastreply.CreationTime
                        };
            var count = await query.CountAsync();

            var result = (await query
                .OrderByDescending(o =>o.latesttime)
                .PageBy(input)
                .ToListAsync())
                .Select(s =>
                {
                    var dto = s.t.MapTo<TopicDto>();
                    dto.Author = s.u.MapTo<TopicAuthorDto>();
                    dto.Node = s.n.MapTo<Node4TopicDto>();
                    dto.LikeCount = s.likes.Count();
                    dto.ReplyCount = s.replies.Count();
                    dto.LatestReplyTime = s.latestreplytime;
                    return dto;
                }).ToList();

            return new PagedResultAndCountOutput<TopicDto>
            {
                TotalCount = count,
                DisplayCount = result.Count(),
                Items = result
            };
        }

        public async Task<ICollection<TopicDto>> GetTopTopics()
        {
            var query = from t in _topicRepository.GetAll()
                        join u in UserManager.Users
                        on t.CreatorUserId equals u.Id

                        join n in _nodeRepository.GetAll()
                        on t.NodeId equals n.Id

                        join l in _likeRepository.GetAll()
                        on new {tid= t.Id,type= LikeType.Topic}
                            equals new { tid= l.TargetId,type= l.Type}
                        into likes

                        join r in _replyRepository.GetAll()
                        on t.Id equals r.TopicId
                        into replies

                        select new { t,u,n,likes,replies};
            var result = (await query.OrderByDescending(o => o.t.CreationTime)
                .Take(10)
                .ToListAsync())
                .Select(s =>
                {
                    var dto = s.t.MapTo<TopicDto>();
                    dto.Author = s.u.MapTo<TopicAuthorDto>();
                    dto.Node = s.n.MapTo<Node4TopicDto>();
                    dto.LikeCount = s.likes.Count();
                    dto.ReplyCount = s.replies.Count();
                    return dto;
                }).ToList();

            return result;
        }


        public async Task<ICollection<RecommendTopicDto>> GetRecommendTopics()
        {
            var query = from t in _topicRepository.GetAll()
                        join r in _replyRepository.GetAll()
                        on t.Id equals r.TopicId
                        into replies

                        select new { t,replies };
            var result = (await query.OrderByDescending(o => o.replies.Count())
                .Take(5)
                .ToListAsync())
                .Select(s =>
                {
                    var dto = s.t.MapTo<RecommendTopicDto>();
                    return dto;
                }).ToList();

            return result;
        }

        public async Task<ICollection<HotTopicDto>> GetHotTopics()
        {
            var query = from t in _topicRepository.GetAll()
                        join r in _replyRepository.GetAll()
                        on t.Id equals r.TopicId
                        into replies

                        select new { t, replies= replies.Count() };
            var result = (await query.OrderByDescending(o => o.replies)
                .Take(5)
                .ToListAsync())
                .Select(s =>
                {
                    var dto = s.t.MapTo<HotTopicDto>();
                    dto.ReplyCount = s.replies;
                    return dto;
                }).ToList();

            return result;
        }

        public async Task<TopicDetailDto> GetTopicDetail(long id)
        {
            var query = from t in _topicRepository.GetAll()
                        join u in UserManager.Users
                        on t.CreatorUserId equals u.Id

                        join r in _replyRepository.GetAll()
                        on t.Id equals r.TopicId
                        into replies
                        select new { t,u,r=replies.Count()};

            var model = await query.Where(w=>w.t.Id == id).FirstOrDefaultAsync();
            if (model == null)
                throw new UserFriendlyException("帖子不存在或已被删除");
            var result = model.t.MapTo<TopicDetailDto>();
            result.ReplyCount = model.r;
            result.Author = model.u.MapTo<TopicAuthorDto>();
            return result;
        }

        public async Task<PagedResultAndCountOutput<MyTopicDto>> GetMyTopics(PagedInputDto input)
        {
            var uid = AbpSession.GetUserId();
            var query = from t in _topicRepository.GetAll()
                        join r in _replyRepository.GetAll()
                        on t.Id equals r.TopicId
                        into replies

                        where t.CreatorUserId == uid
                        select new { t,replies=replies.Count()};

            var count = await query.CountAsync();

            var items = (await query.OrderByDescending(o=>o.t.CreationTime)
                .PageBy(input)
                .ToListAsync())
                .Select(s=> {
                    var dto = s.t.MapTo<MyTopicDto>();
                    dto.ReplyCount = s.replies;
                    return dto;
                })
                .ToList();
            return new PagedResultAndCountOutput<MyTopicDto>
            {
                TotalCount = count,
                DisplayCount = items.Count(),
                Items = items
            };
        }

        public async Task<PagedResultAndCountOutput<MyCollectionTopicDto>> GetMyCollectionTopics(PagedInputDto input)
        {
            var uid = AbpSession.GetUserId();
            var query = from c in _collectionRepository.GetAll()
                        join t in _topicRepository.GetAll()
                        on c.TargetId equals t.Id
                        where c.Type == CollectionType.Topic
                        && c.CreatorUserId == uid

                        select new {c,t };
            var count = await query.CountAsync();
            var items = (await query.OrderByDescending(o => o.c.CreationTime)
                .PageBy(input)
                .ToListAsync())
                .Select(s =>
                {
                    var dto =s.t.MapTo<MyCollectionTopicDto>();
                    dto.CollectionTime = s.c.CreationTime;
                    return dto;
                })
                .ToList();

            return new PagedResultAndCountOutput<MyCollectionTopicDto>
            {
                TotalCount = count,
                DisplayCount = items.Count(),
                Items = items
            };
        }
    }
}
