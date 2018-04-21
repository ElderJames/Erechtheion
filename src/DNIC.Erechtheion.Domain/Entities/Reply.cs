using System;
using DNIC.Erechtheion.Application.EnumTypes;
using DNIC.Erechtheion.Core.CustomExceptions;
using DNIC.Erechtheion.Core.Database;
using DNIC.Erechtheion.Core.Domain.Entities;
using DNIC.Erechtheion.Core.Extensions;

namespace DNIC.Erechtheion.Domain.Entities
{
	/// <summary>
	/// 回复实体
	/// </summary>
	public class Reply : AuditedAggregateRoot<int, Guid>, ISoftDeletable
	{
		private Reply() : base(Guid.Empty)
		{
		}

		public Reply(Guid aggregateId, Guid targetId, ReplyTargets target, long userId, string content) : base(aggregateId)
		{
			if (content.IsNullOrEmpty())
				throw new DomainException("内容不能为空");

			this.ContentId = ContentId;
			this.TargetId = targetId;
			this.Target = target;
			this.UserId = userId;
			this.Content = content;
		}

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
		/// 回复内容
		/// </summary>
		public string Content { get; private set; }

		public void Change(string content)
		{
			if (content.IsNullOrEmpty())
				throw new DomainException("内容不能为空");

			this.Content = content;
		}
	}
}