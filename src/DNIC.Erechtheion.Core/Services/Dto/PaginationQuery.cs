namespace DNIC.Erechtheion.Core.Services.Dto
{
	public class PaginationQuery
	{
		public virtual int Page { get; set; }
		public virtual int PageSize { get; set; }
		public virtual string Sort { get; set; }
	}
}
