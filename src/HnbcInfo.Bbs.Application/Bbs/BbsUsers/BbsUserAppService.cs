using Abp.Domain.Repositories;
using HnbcInfo.Bbs.Bbs.BbsUsers.Dtos;
using HnbcInfo.Bbs.Bbs.Replies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.AutoMapper;
using Abp.UI;
using HnbcInfo.Bbs.Bbs.Bonuses;
using HnbcInfo.Bbs.Bbs.Topics;
using Abp.Runtime.Session;

namespace HnbcInfo.Bbs.Bbs.BbsUsers
{
    public class BbsUserAppService : BbsAppServiceBase, IBbsUserAppService
    {
        private readonly IRepository<Reply, long> _replyRepository;
        private readonly IRepository<Topic, long> _topicRepository;
        private readonly IRepository<Bonus, long> _bonusRepository;

        public BbsUserAppService(IRepository<Reply, long> replyRepository,
            IRepository<Topic, long> topicRepository,
            IRepository<Bonus, long> bonusRepository)
        {
            _replyRepository = replyRepository;
            _topicRepository = topicRepository;
            _bonusRepository = bonusRepository;
        }


        public async Task<ICollection<ReplyRankUserDto>> GetReplyRank()
        {
            var query = from u in UserManager.Users
                        join r in _replyRepository.GetAll()
                        on u.Id equals r.CreatorUserId
                        into replies

                        select new { u, replies };

            var result = (await query.OrderByDescending(o => o.replies.Count())
                .Take(10)
                .ToListAsync())
                .Select(s => {
                    var dto = s.u.MapTo<ReplyRankUserDto>();
                    dto.ReplyCount = s.replies.Count();
                    return dto;
                })
                .ToList();

            return result;
        }

        public async Task<UserWithTopicAndReplyDto> GetUserInfo(long id)
        {
            var query = from u in UserManager.Users
                        join b in _bonusRepository.GetAll()
                        on u.Id equals b.UserId
                        into bonus
                        
                        where u.Id == id
                        select new { u,
                            bonus=bonus.Sum(s=>s.Points)                          
                        };


            var q_topic = from t in _topicRepository.GetAll()
                          join r in _replyRepository.GetAll()
                          on t.Id equals r.TopicId
                          into replies
                          where t.CreatorUserId == id
                          select new { t, replies = replies.Count() };

            var q_reply = from r in _replyRepository.GetAll()
                          join t in _topicRepository.GetAll()
                          on r.TopicId equals t.Id

                          where r.CreatorUserId == id
                          select new { t, r };


            var user = await query.FirstOrDefaultAsync();

            if (user == null)
                throw new UserFriendlyException("用户不存在");
            
            var result = user.u.MapTo<UserWithTopicAndReplyDto>();
            result.Bonus = user.bonus;
            result.Topics =(await q_topic.OrderByDescending(o=>o.t.CreationTime)
                .Take(AppConsts.UserHomeTopicCount)
                .ToListAsync())
                .Select(s=> {
                    var dto = s.t.MapTo<Topic4UserInfoDto>();
                    dto.ReplyCount = s.replies;
                    return dto;
                })
                .ToList();

            result.Replies = (await q_reply.OrderByDescending(o => o.t.CreationTime)
                .Take(AppConsts.UserHomeReplyCount)
                .ToListAsync())
                .Select(s => {
                    var dto = s.r.MapTo<Reply4UserInfoDto>();
                    dto.Topic = s.t.MapTo<Topic4ReplyDto>();
                    return dto;
                })
                .ToList();

            return result;
        }


        public async Task<MyBaseInfoDto> GetMyBaseInfo()
        {
            var uid = AbpSession.GetUserId();
            var user = await UserManager.Users
                .Where(w=>w.Id == uid)
                .FirstOrDefaultAsync();
            if (user == null)
                throw new UserFriendlyException("用户信息不存在，请重新登录");

            return user.MapTo<MyBaseInfoDto>();
            
        }
    }
}
