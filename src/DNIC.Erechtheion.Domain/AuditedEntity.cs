using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Domain
{
	public interface IAuditedEntity
	{
		//
		// 摘要:
		//     Last modification date of this entity.
		DateTime? LastModificationTime { get; set; }

		//
		// 摘要:
		//     Last modifier user of this entity.
		long? LastModifierUserId { get; set; }

		//
		// 摘要:
		//     Creation time of this entity.
		DateTime CreationTime { get; set; }

		//
		// 摘要:
		//     Creator of this entity.
		long? CreatorUserId { get; set; }
	}

	public abstract class AuditedEntity<TAggregateId> : Entity<TAggregateId>, IAuditedEntity where TAggregateId : IEquatable<TAggregateId>
	{
		public virtual DateTime? LastModificationTime { get; set; }
		public virtual long? LastModifierUserId { get; set; }
		public virtual DateTime CreationTime { get; set; }
		public virtual long? CreatorUserId { get; set; }

		protected AuditedEntity(TAggregateId aggregateId) : base(aggregateId)
		{
			CreationTime = DateTime.Now;
		}
	}

	/// <summary>
	/// 定义默认主键类型为long的实体基类
	/// </summary>
	public abstract class AuditedEntity : AuditedEntity<long>
	{
		protected AuditedEntity(long aggregateId) : base(aggregateId)
		{
		}
	}
}