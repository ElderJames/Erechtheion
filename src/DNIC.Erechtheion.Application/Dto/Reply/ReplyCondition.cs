using System;
using DNIC.Erechtheion.Core.Services.Dto;

namespace DNIC.Erechtheion.Application.Dto.Reply
{
	public class ReplyCondition : PaginationQuery
	{
		/// <summary>
		/// 回复者Id
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 回复内容Id
		/// </summary>
		public Guid TargetId { get; set; }

		/// <summary>
		/// 内容Id
		/// </summary>
		public Guid ContentId { get; set; }
	}
}