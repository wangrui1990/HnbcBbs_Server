using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HnbcInfo.Bbs.Bbs.Replies.Dtos;
using HnbcInfo.Bbs.Dtos;
using HnbcInfo.Bbs.Bbs.Likes;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Linq.Extensions;
using Abp.AutoMapper;
using HnbcInfo.Bbs.Bbs.Topics.Dtos;

namespace HnbcInfo.Bbs.Bbs.Replies
{
    public class ReplyAppService : BbsAppServiceBase, IReplyAppService
    {
        private readonly IRepository<Reply, long> _replyRepository;
        private readonly IRepository<Like, long> _likeRepository;

        public ReplyAppService(IRepository<Reply, long> replyRepository,
            IRepository<Like, long> likeRepository)
        {
            _replyRepository = replyRepository;
            _likeRepository = likeRepository;
        }

        public async Task<PagedResultAndCountOutput<ReplyDto>> GetReplies(GetRepliesInput input)
        {
            var query = from r in _replyRepository.GetAll()
                        join u in UserManager.Users
                        on r.CreatorUserId equals u.Id

                        join l in _likeRepository.GetAll()
                        on new { rid = r.Id, t = LikeType.Reply }
                            equals new { rid = l.TargetId, t = l.Type }
                        into likes

                        where r.TopicId == input.TopicId
                        select new { r, u, likes = likes.Count() };

            var count = await query.CountAsync();

            var items = (await query.OrderBy(o => o.r.CreationTime)
                .PageBy(input)
                .ToListAsync())
                .Select(s =>
                {
                    var dto = s.r.MapTo<ReplyDto>();
                    dto.LikeCount = s.likes;
                    dto.Author = s.u.MapTo<TopicAuthorDto>();
                    return dto;
                })
                .ToList();
            return new PagedResultAndCountOutput<ReplyDto>
            {
                TotalCount = count,
                DisplayCount = items.Count(),
                Items = items
            };
        }
    }
}
