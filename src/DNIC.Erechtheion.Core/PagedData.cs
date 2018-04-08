using System.Collections;
using System.Collections.Generic;

namespace DNIC.Erechtheion.Core
{
    public class PagedData<T> where T : new()
    {
        public PagedData(int pageNow, int pageSize, int totalCount, IEnumerable<T> records)
        {
            this.PageNow = pageNow;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.Records = records;
        }

        public int PageSize { get; }

        public int PageNow { get; }

        public int TotalCount { get; }

        public IEnumerable<T> Records { get; }
    }
}