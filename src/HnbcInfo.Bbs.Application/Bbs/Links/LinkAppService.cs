using Abp.AutoMapper;
using Abp.Domain.Repositories;
using HnbcInfo.Bbs.Bbs.Links.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs.Links
{
    public class LinkAppService : BbsAppServiceBase, ILinkAppService
    {
        private readonly IRepository<Link, long> _linkRepository;

        public LinkAppService(IRepository<Link, long> linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public async Task<ICollection<LinkDto>> GetLinks()
        {
            var result = (await _linkRepository.GetAll()
                .OrderByDescending(o => o.Order)
                .Take(AppConsts.DefaultLinkCount)
                .ToListAsync())
                .Select(s => s.MapTo<LinkDto>())
                .ToList();
            return result;
        }
    }
}
