using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Dtos
{
    public class PagedAndFilteredInputDto : PagedInputDto
    {
        public string Filter { get; set; }

        public PagedAndFilteredInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}
