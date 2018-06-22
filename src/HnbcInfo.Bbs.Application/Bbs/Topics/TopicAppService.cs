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

namespace HnbcInfo.Bbs.Bbs.Topics
{
    public class TopicAppService : BbsAppServiceBase, ITopicAppService
    {
        private readonly IRepository<Node, long> _nodeRepository;
        private readonly IRepository<Topic, long> _topicRepository;
        private readonly IRepository<Like, long> _likeRepository;
        private readonly IRepository<Reply, long> _replyRepository;

        public TopicAppService(IRepository<Node, long> nodeRepository,
            IRepository<Topic, long> topicRepository,
            IRepository<Like, long> likeRepository,
            IRepository<Reply, long> replyRepository)
        {
            _nodeRepository = nodeRepository;
            _topicRepository = topicRepository;
            _likeRepository = likeRepository;
            _replyRepository = replyRepository;
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
    }
}
