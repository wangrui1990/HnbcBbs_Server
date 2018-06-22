using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using HnbcInfo.Bbs.Authorization;
using HnbcInfo.Bbs.Authorization.Roles;
using HnbcInfo.Bbs.Authorization.Users;
using HnbcInfo.Bbs.Editions;
using HnbcInfo.Bbs.MultiTenancy;

namespace HnbcInfo.Bbs.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
