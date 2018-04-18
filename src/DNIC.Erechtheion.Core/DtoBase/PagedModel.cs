using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.DtoBase
{
	public class PagedModel<T> where T : class
	{
		public PagedModel(int pageNow, int pageSize, int totalCount, IEnumerable<T> data)
		{
			this.Page = pageNow;
			this.PageSize = pageSize;
			this.TotalCount = totalCount;
			this.Data = data;
		}

		public int PageSize { get; }

		public int Page { get; }

		public int TotalCount { get; }

		public IEnumerable<T> Data { get; }
	}
}
