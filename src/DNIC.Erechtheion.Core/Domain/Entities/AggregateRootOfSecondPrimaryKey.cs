using DNIC.Erechtheion.Core.EventBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain.Entities
{
	public abstract class AggregateRootOfSecondPrimaryKey : AggregateRootOfSecondPrimaryKey<int, Guid>, IAggregateRoot
	{
	}

	public abstract class AggregateRootOfSecondPrimaryKey<TPrimaryKey, TSecondPrimaryKey> : Entity<TPrimaryKey>, IAggregateRoot<TPrimaryKey>
	{
		/// <summary>
		/// Unique identifier for this entity.
		/// </summary>
		public virtual TPrimaryKey SecondId { get; set; }

		public virtual ICollection<IEventData> DomainEvents { get; }

		public AggregateRootOfSecondPrimaryKey()
		{
			DomainEvents = new Collection<IEventData>();
		}
	}
}
