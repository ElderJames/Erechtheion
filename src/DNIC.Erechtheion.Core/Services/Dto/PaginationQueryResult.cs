using System.Collections.Generic;

namespace DNIC.Erechtheion.Core.Services.Dto
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
