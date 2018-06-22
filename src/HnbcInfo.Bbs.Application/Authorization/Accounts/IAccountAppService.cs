using System.Threading.Tasks;
using Abp.Application.Services;
using HnbcInfo.Bbs.Authorization.Accounts.Dto;

namespace HnbcInfo.Bbs.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
