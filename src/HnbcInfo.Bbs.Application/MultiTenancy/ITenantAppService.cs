using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HnbcInfo.Bbs.MultiTenancy.Dto;

namespace HnbcInfo.Bbs.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
