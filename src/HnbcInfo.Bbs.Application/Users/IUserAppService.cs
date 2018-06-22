using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using HnbcInfo.Bbs.Roles.Dto;
using HnbcInfo.Bbs.Users.Dto;

namespace HnbcInfo.Bbs.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
