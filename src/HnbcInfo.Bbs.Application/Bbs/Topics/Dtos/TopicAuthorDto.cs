using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using HnbcInfo.Bbs.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Bbs.Topics.Dtos
{
    [AutoMapFrom(typeof(User))]
    public class TopicAuthorDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Avatar { get; set; }

        public int Vip { get; set; }

        public string Renzheng { get; set; }

    }
}
