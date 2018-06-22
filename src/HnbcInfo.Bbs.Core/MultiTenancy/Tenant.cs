using Abp.MultiTenancy;
using HnbcInfo.Bbs.Authorization.Users;

namespace HnbcInfo.Bbs.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
