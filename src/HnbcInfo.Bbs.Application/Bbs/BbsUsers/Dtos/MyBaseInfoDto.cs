using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HnbcInfo.Bbs.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.BbsUsers.Dtos
{
    [AutoMapFrom(typeof(User))]
    public class MyBaseInfoDto:EntityDto<long>
    {
        public virtual string Avatar { get; set; }

        public virtual string Name { get; set; }

        public virtual string EmailAddress { get; set; }

        public virtual string From { get; set; }

        public virtual string Signature { get; set; }
    }
}
