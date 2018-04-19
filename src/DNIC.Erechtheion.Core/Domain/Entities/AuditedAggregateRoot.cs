using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain.Entities
{
	public abstract class AuditedAggregateRoot : AggregateRoot, IAudited
	{
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
