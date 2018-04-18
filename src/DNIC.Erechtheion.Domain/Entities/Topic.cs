using System;
using DNIC.Erechtheion.Core.Domain;
using DNIC.Erechtheion.Core.EnumTypes;

namespace DNIC.Erechtheion.Domain.Entities
{
	public class Topic : DisableAggregateRootEntity
	{
		#region ctor

		public Topic(Guid aggregateId, long authorId, Guid channelId, string title, string slug,
			ContentTypes contentType, string content, SubjectStates state) : base(aggregateId)
		{
			this.AuthorId = authorId;
			this.ChannelId = channelId;
			this.Title = title;
			this.Slug = slug;
			this.ContentType = contentType;
			this.Content = content;
			this.State = state;
		}

		protected Topic() : base(Guid.Empty)
		{
		}

		#endregion ctor

		#region prop

		public long AuthorId { get; private set; }

		/// <summary>
		/// 板块id
		/// </summary>
		public Guid ChannelId { get; private set; }

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
		public ContentTypes ContentType { get; private set; }

		/// <summary>
		/// 内容
		/// </summary>
		public string Content { get; private set; }

		/// <summary>
		/// 评论数
		/// </summary>
		public int Comments { get; private set; }

		/// <summary>
		/// 点赞数
		/// </summary>
		public int Likes { get; private set; }

		/// <summary>
		/// 点击量
		/// </summary>
		public int Hits { get; private set; }

		/// <summary>
		/// 状态
		/// </summary>
		public SubjectStates State { get; private set; }

		/// <summary>
		/// 删除
		/// </summary>
		public bool Deleted { get; private set; }

		#endregion prop

		#region actions

		public void Change(Guid channelId, string title, string slug, ContentTypes contentType, string content, SubjectStates state)
		{
			this.ChannelId = channelId;
			this.Title = title;
			this.Slug = slug;
			this.ContentType = contentType;
			this.Content = content;
			this.State = state;
		}

		public void AddComments()
		{
			this.Comments++;
		}

		public void SubtractComments()
		{
			if (this.Comments <= 0)
				return;

			this.Comments--;
		}

		public void AddHits()
		{
			this.Hits++;
		}

		public void AddLikes()
		{
			this.Likes++;
		}

		public void SubtractLikes()
		{
			if (this.Likes <= 0)
				return;

			this.Likes--;
		}

		#endregion actions
	}
}