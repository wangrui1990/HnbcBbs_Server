using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Dtos
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        public string Sorting { get; set; }

        public PagedAndSortedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}
