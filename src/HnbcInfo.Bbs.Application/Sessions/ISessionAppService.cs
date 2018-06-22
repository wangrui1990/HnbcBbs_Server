using System.Threading.Tasks;
using Abp.Application.Services;
using HnbcInfo.Bbs.Sessions.Dto;

namespace HnbcInfo.Bbs.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
