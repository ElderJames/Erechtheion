using DNIC.Erechtheion.Core.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.DtoBase
{
	public class PaginationQueryResult<TEntity> where TEntity : IEntityDto
	{
		public virtual int TotalCount { get; private set; }
		public virtual int Page { get; private set; }
		public virtual int PageSize { get; private set; }

		public virtual IEnumerable<TEntity> Data { get; }

		public PaginationQueryResult(int page, int pageSize, int totalCount, IEnumerable<TEntity> data)
		{
			Page = page;
			PageSize = pageSize;
			TotalCount = totalCount;
			Data = data;
		}
	}
}
