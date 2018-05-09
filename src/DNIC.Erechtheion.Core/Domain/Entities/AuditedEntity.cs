using System;

namespace DNIC.Erechtheion.Core.Domain.Entities
{
	/// <summary>
	/// A shortcut of <see cref="AuditedEntity{TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
	/// </summary>
	[Serializable]
	public abstract class AuditedEntity : AuditedEntity<int>, IEntity
	{
	}

	/// <summary>
	/// This class can be used to simplify implementing <see cref="IAudited"/>.
	/// </summary>
	/// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
	[Serializable]
	public abstract class AuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, IAudited
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
