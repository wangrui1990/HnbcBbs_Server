using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.Extensions;
using HnbcInfo.Bbs.Validation;

namespace HnbcInfo.Bbs.Authorization.Accounts.Dto
{
    public class RegisterInput
    {
        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }
        
        //[Required]
        //[StringLength(AbpUserBase.MaxUserNameLength)]
        //public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        [DisableAuditing]
        public string CaptchaResponse { get; set; }        
    }
}
