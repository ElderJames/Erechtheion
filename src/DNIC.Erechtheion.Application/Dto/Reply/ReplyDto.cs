using System;
using DNIC.Erechtheion.Application.EnumTypes;
using DNIC.Erechtheion.Core.Services.Dto;

namespace DNIC.Erechtheion.Application.Dto.Reply
{
	public class ReplyDto : IEntityDto
	{
		public int Id { get; set; }

		public Guid AggregateId { get; set; }

		/// <summary>
		/// 内容Id
		/// </summary>
		public Guid ContentId { get; set; }

		/// <summary>
		/// 回复对象Id
		/// </summary>
		public Guid TargetId { get; set; }

		/// <summary>
		/// 回复对象类型
		/// </summary>
		public ReplyTargets Target { get; set; }

		/// <summary>
		/// 回复者Id
		/// </summary>
		public long UserId { get; set; }

		/// <summary>
		/// 内容类型
		/// </summary>
		public ContentType ContentType { get; set; }

		/// <summary>
		/// 回复内容
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// 关闭
		/// </summary>
		public bool Closed { get; set; }

		/// <summary>
		/// Last modification date of this entity.
		/// </summary>
		public virtual DateTime? LastModificationTime { get; set; }

		/// <summary>
		/// Last modifier user of this entity.
		/// </summary>
		public virtual long? LastModifierUserId { get; set; }

		/// <summary>
		/// Creation time of this entity.
		/// </summary>
		public virtual DateTime? CreationTime { get; set; }

		/// <summary>
		/// Creator of this entity.
		/// </summary>
		public virtual long? CreatorUserId { get; set; }
	}
}