using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HnbcInfo.Bbs.Dtos
{
    public class PagedResultAndCountOutput<T> : PagedResultDto<T>
    {
        public int DisplayCount { get; set; }

        public PagedResultAndCountOutput()
        {
        }

        public PagedResultAndCountOutput(int displayCount, int totalCount, IReadOnlyList<T> items)
            : base(totalCount, items)
        {
            DisplayCount = displayCount;
        }
    }
}
