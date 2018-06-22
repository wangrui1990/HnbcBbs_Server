using Abp.Authorization;
using HnbcInfo.Bbs.Authorization.Roles;
using HnbcInfo.Bbs.Authorization.Users;

namespace HnbcInfo.Bbs.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
