using System.Collections.Generic;

namespace DNIC.Erechtheion.Core
{
    public class PagedData<T> where T : new()
    {
        public int PageSize { get; set; }

        public int PageNow { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<T> Records { get; set; }
    }
}