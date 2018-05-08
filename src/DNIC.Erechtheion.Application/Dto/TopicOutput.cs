using System;
using System.Collections.Generic;
using DNIC.Erechtheion.Application.EnumTypes;

namespace DNIC.Erechtheion.Application.Dto
{
	public class TopicOutput
	{
		public Guid AggregateId { get; set; }

		/// <summary>
		/// 标题
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// 友好链接标识（把标题翻译成英文）
		/// </summary>
		public string Slug { get; set; }

		/// <summary>
		/// 内容类型
		/// </summary>
		public ContentType ContentType { get; set; }

		/// <summary>
		/// 内容
		/// </summary>
		public string Content { get; set; }

		/// <summary>
		/// 状态
		/// </summary>
		public ContentState State { get; set; }

		/// <summary>
		/// 是否删除
		/// </summary>
		public bool Deleted { get; set; }

		/// <summary>
		/// 删除时间
		/// </summary>
		public DateTime? DeletionTime { get; set; }

		/// <summary>
		/// 阅读数
		/// </summary>
		public int ViewCount { get; set; }

		/// <summary>
		/// 点赞数
		/// </summary>
		public int LikeCount { get; set; }

		/// <summary>
		/// 否定数
		/// </summary>
		public int DenyCount { get; set; }

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