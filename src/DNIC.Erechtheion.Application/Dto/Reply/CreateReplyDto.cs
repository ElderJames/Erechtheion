using System;
using DNIC.Erechtheion.Application.EnumTypes;

namespace DNIC.Erechtheion.Application.Dto.Reply
{
	public class CreateReplyDto
	{
		/// <summary>
		/// 内容Id
		/// </summary>
		public Guid ContentId { get; private set; }

		/// <summary>
		/// 回复对象Id
		/// </summary>
		public Guid TargetId { get; private set; }

		/// <summary>
		/// 回复对象类型
		/// </summary>
		public ReplyTargets Target { get; private set; }

		/// <summary>
		/// 回复者Id
		/// </summary>
		public long UserId { get; private set; }

		/// <summary>
		/// 内容类型
		/// </summary>
		public ContentType ContentType { get; private set; }

		/// <summary>
		/// 回复内容
		/// </summary>
		public string Content { get; private set; }
	}
}