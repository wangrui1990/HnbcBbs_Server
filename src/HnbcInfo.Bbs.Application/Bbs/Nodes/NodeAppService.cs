using System;
using System.Collections.Generic;
using System.Text;
using HnbcInfo.Bbs.Bbs.Nodes.Dtos;
using Abp.Domain.Repositories;
using System.Linq;
using Abp.AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace HnbcInfo.Bbs.Bbs.Nodes
{
    public class NodeAppService : BbsAppServiceBase, INodeAppService
    {
        private readonly IRepository<Node, long> _nodeRepository;

        public NodeAppService(IRepository<Node, long> nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public async Task<ICollection<NodeNavigationDto>> GetNavigations()
        {
            var nodes = (await _nodeRepository.GetAll()
                .OrderBy(o => o.Id)
                .Take(BbsConsts.NavigationNodeCount)
                .ToListAsync()
                )
                .Select(s => s.MapTo<NodeNavigationDto>())
                .ToList();

            nodes.Insert(0, new NodeNavigationDto { Name = "首页", Url = "/#", IsNew = false });
            return nodes;
        }
    }
}
