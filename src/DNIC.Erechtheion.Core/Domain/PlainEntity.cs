using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain
{
	/// <summary>
	/// 领域实体基类
	/// </summary>
	[Serializable]
	public abstract class PlainEntity<TPrimaryKey> : ISoftDelete, IAudited
	{
		/// <summary>
		/// 构造器
		/// </summary>
		protected PlainEntity()
		{
		}

		public TPrimaryKey Id { get; set; }

		/// <summary>
		/// Id of the creator user of this entity.
		/// </summary>
		public virtual long? CreatorUserId { get; set; }

		/// <summary>
		/// Creation time of this entity.
		/// </summary>
		public virtual DateTime? CreationTime { get; set; }

		/// <summary>
		/// Last modifier user for this entity.
		/// </summary>
		public virtual long? LastModifierUserId { get; set; }

		/// <summary>
		/// The last modified time for this entity.
		/// </summary>
		public virtual DateTime? LastModificationTime { get; set; }

		/// <summary>
		/// Used to mark an Entity as 'Deleted'. 
		/// </summary>
		public virtual bool IsDeleted { get; set; }

		/// <summary>
		/// Deletion time of this entity.
		/// </summary>
		public virtual DateTime? DeletionTime { get; set; }
	}

	[Serializable]
	public abstract class PlainEntity : PlainEntity<long>
	{
	}
}
