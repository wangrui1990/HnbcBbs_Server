using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using HnbcInfo.Bbs.Bbs.Ads.Dtos;
using System.Threading.Tasks;
using System.Linq;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using Abp.AutoMapper;

namespace HnbcInfo.Bbs.Bbs.Ads
{
    public class AdAppService : BbsAppServiceBase, IAdAppService
    {
        private readonly IRepository<Ad, long> _adRepository;
        private readonly IRepository<AdDeploy, long> _adDeployRepository;

        public AdAppService(IRepository<Ad, long> adRepository,
            IRepository<AdDeploy, long> adDeployRepository)
        {
            _adRepository = adRepository;
            _adDeployRepository = adDeployRepository;
        }

        public async Task<SideAdDto> GetSideAd(long nodeId)
        {
            var query = from ad in _adRepository.GetAll()
                        join deploy in _adDeployRepository.GetAll()
                        on ad.Id equals deploy.AdId
                        select new { ad,deploy};

            query = query.Where(w => w.deploy.DeployType == AdDeployType.Side)
                    .WhereIf(nodeId > 0, w => w.deploy.TargetId == nodeId);
            var result = (await query.OrderBy(o => new Random().Next())
                .FirstOrDefaultAsync())
                ?.ad?.MapTo<SideAdDto>();
            return result;
        }
    }
}
