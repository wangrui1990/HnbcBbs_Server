﻿using System;
using Abp.Authorization.Users;
using Abp.Extensions;

namespace HnbcInfo.Bbs.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public virtual string Avatar { get; set; }

        public virtual int Vip { get; set; }

        public virtual string Renzheng { get; set; }

        public virtual string From { get; set; }

        public virtual string Signature { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
