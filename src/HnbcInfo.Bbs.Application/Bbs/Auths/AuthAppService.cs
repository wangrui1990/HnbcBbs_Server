using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Zero.Configuration;
using HnbcInfo.Bbs.Authorization.Accounts.Dto;
using HnbcInfo.Bbs.Authorization.Users;

namespace HnbcInfo.Bbs.Bbs.Auths
{
    public class AuthAppService : BbsAppServiceBase, IAuthAppService
    {
        private readonly UserRegistrationManager _userRegistrationManager;

        public AuthAppService(UserRegistrationManager userRegistrationManager)
        {
            _userRegistrationManager = userRegistrationManager;
        }
        //public async Task<RegisterOutput> Register(RegisterInput input)
        //{
        //    var user = await _userRegistrationManager.RegisterAsync(
        //        input.Name,
        //        input.Name,
        //        input.EmailAddress,
        //        input.EmailAddress,
        //        input.Password,
        //        true // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
        //    );

        //    var isEmailConfirmationRequiredForLogin = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);

        //    return new RegisterOutput
        //    {
        //        CanLogin = user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin)
        //    };
        //}

    }
}
