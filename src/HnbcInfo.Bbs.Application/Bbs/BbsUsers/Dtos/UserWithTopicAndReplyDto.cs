using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HnbcInfo.Bbs.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.BbsUsers.Dtos
{
    [AutoMapFrom(typeof(User))]
    public class UserWithTopicAndReplyDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Avatar { get; set; }
        public string Renzheng { get; set; }

        public int Vip { get; set; }

        public DateTime CreationTime { get; set; }

        public int Bonus { get; set; }

        public string From { get; set; }

        public string Signature { get; set; }

        public ICollection<Topic4UserInfoDto> Topics { get; set; }

        public ICollection<Reply4UserInfoDto> Replies { get; set; }        

    }
}
