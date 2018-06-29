using Abp.Application.Services;
using HnbcInfo.Bbs.Bbs.BbsUsers.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs.BbsUsers
{
    public interface IBbsUserAppService : IApplicationService
    {
        Task<ICollection<ReplyRankUserDto>> GetReplyRank();

        Task<UserWithTopicAndReplyDto> GetUserInfo(long id);


        Task<MyBaseInfoDto> GetMyBaseInfo();
    }
}
