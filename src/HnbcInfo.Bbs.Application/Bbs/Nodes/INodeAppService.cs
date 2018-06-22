using Abp.Application.Services;
using HnbcInfo.Bbs.Bbs.Nodes.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HnbcInfo.Bbs.Bbs.Nodes
{
    public interface INodeAppService : IApplicationService
    {
        Task<ICollection<NodeNavigationDto>> GetNavigations();
    }
}
