using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Dtos
{
    public class PagedSortedAndFilteredInputDto : PagedAndSortedInputDto
    {
        public string Filter { get; set; }

        public PagedSortedAndFilteredInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}
