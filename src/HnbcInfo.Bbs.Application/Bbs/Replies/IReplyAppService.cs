using Abp.Application.Services;
using HnbcInfo.Bbs.Bbs.Replies.Dtos;
using HnbcInfo.Bbs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs.Replies
{
    public interface IReplyAppService : IApplicationService
    {
        Task<PagedResultAndCountOutput<ReplyDto>> GetReplies(GetRepliesInput input);
    }
}
