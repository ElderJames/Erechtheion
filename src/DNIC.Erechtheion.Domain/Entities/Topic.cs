using System;
using DNIC.Erechtheion.Core.Domain;
using DNIC.Erechtheion.Core.Domain.Entities;
using DNIC.Erechtheion.Core.EnumTypes;

namespace DNIC.Erechtheion.Domain.Entities
{
	public class Topic : AuditedAggregateRoot, IDisable, ISoftDelete
	{
		#region ctor

		public Topic(int channelId, string title, string slug,
			ContentType contentType, string content, TopicState state)
		{
			this.ChannelId = channelId;
			this.Title = title;
			this.Slug = slug;
			this.ContentType = contentType;
			this.Content = content;
			this.State = state;
		}

		protected Topic()
		{
		}

		#endregion ctor

		#region prop

		/// <summary>
		/// 板块id
		/// </summary>
		public int ChannelId { get; private set; }

		/// <summary>
		/// 标题
		/// </summary>
		public string Title { get; private set; }

		/// <summary>
		/// 友好链接标识（把标题翻译成英文）
		/// </summary>
		public string Slug { get; private set; }

		/// <summary>
		/// 是否锁定
		/// </summary>
		public bool Locked { get; private set; }

		/// <summary>
		/// 内容类型
		/// </summary>
		public ContentType ContentType { get; private set; }

		/// <summary>
		/// 内容
		/// </summary>
		public string Content { get; private set; }

		/// <summary>
		/// 状态
		/// </summary>
		public TopicState State { get; private set; }

		/// <summary>
		/// 是否启用
		/// </summary>
		public bool Enabled { get; private set; }

		/// <summary>
		/// 是否删除
		/// </summary>
		public bool IsDeleted { get; private set; }

		/// <summary>
		/// 删除时间
		/// </summary>
		public DateTime? DeletionTime { get; private set; }

		#endregion prop

		#region disbable

		public void Enable()
		{
			if (Enabled)
			{
				return;
			}

			Enabled = true;
		}

		public void Disable()
		{
			if (!Enabled)
			{
				return;
			}

			Enabled = false;
		}

		#endregion

		#region soft delete

		public void Delete()
		{
			if (IsDeleted)
			{
				return;
			}

			IsDeleted = true;
			DeletionTime = DateTime.Now;
		}

		#endregion

		#region actions

		public void Change(int channelId, string title, string slug, ContentType contentType, string content, TopicState state)
		{
			this.ChannelId = channelId;
			this.Title = title;
			this.Slug = slug;
			this.ContentType = contentType;
			this.Content = content;
			this.State = state;
		}

		#endregion actions
	}
}