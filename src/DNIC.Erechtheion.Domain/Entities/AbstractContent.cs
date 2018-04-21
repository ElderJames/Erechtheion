using DNIC.Erechtheion.Core.Domain;
using DNIC.Erechtheion.Core.Domain.Entities;
using DNIC.Erechtheion.Core.EnumTypes;
using System;
using System.Collections.Generic;
using DNIC.Erechtheion.Domain.ValueObjects;

namespace DNIC.Erechtheion.Domain.Entities
{
	public abstract class AbstractContent : AuditedAggregateRoot<int, Guid>, ISoftDelete
	{
		#region ctor

		public AbstractContent(Guid aggregateId, ICollection<ContentChannels> channels, string title, string slug, ContentType contentType, string content, ContentState state) : base(aggregateId)
		{
			this.Channels = channels;
			this.Title = title;
			this.Slug = slug;
			this.ContentType = contentType;
			this.Content = content;
			this.State = state;
		}

		protected AbstractContent() : base(Guid.Empty)
		{
		}

		#endregion ctor

		#region prop

		/// <summary>
		/// 标题
		/// </summary>
		public string Title { get; protected set; }

		/// <summary>
		/// 友好链接标识（把标题翻译成英文）
		/// </summary>
		public string Slug { get; protected set; }

		/// <summary>
		/// 内容类型
		/// </summary>
		public ContentType ContentType { get; protected set; }

		/// <summary>
		/// 内容
		/// </summary>
		public string Content { get; protected set; }

		/// <summary>
		/// 内容所属所有频道
		/// </summary>
		public ICollection<ContentChannels> Channels { get; protected set; }

		/// <summary>
		/// 状态
		/// </summary>
		public ContentState State { get; protected set; }

		/// <summary>
		/// 是否删除
		/// </summary>
		public bool Deleted { get; protected set; }

		/// <summary>
		/// 删除时间
		/// </summary>
		public DateTime? DeletionTime { get; protected set; }

		#endregion prop

		#region soft delete

		public void Delete()
		{
			if (Deleted)
			{
				return;
			}

			Deleted = true;
			DeletionTime = DateTime.Now;
		}

		#endregion soft delete
	}
}