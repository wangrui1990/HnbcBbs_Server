using Abp.Application.Services;
using HnbcInfo.Bbs.Bbs.Links.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs.Links
{
    public interface ILinkAppService : IApplicationService
    {
        Task<ICollection<LinkDto>> GetLinks();
    }
}
