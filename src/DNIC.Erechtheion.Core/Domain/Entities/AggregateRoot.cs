using DNIC.Erechtheion.Core.EventBase;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DNIC.Erechtheion.Core.Domain.Entities
{
	public abstract class AggregateRoot : AggregateRoot<int>, IAggregateRoot
	{
	}

	public abstract class AggregateRoot<TPrimaryKey> : Entity<TPrimaryKey>, IAggregateRoot<TPrimaryKey>
	{
		public virtual ICollection<IEventData> DomainEvents { get; }

		public AggregateRoot()
		{
			DomainEvents = new Collection<IEventData>();
		}
	}

	public abstract class AggregateRoot<TPrimaryKey, TAggregateId> : Entity<TPrimaryKey>, IAggregateRoot<TPrimaryKey>
	{
		public virtual ICollection<IEventData> DomainEvents { get; }

		public virtual TAggregateId AggregateId { get; }

		public AggregateRoot(TAggregateId aggregateId)
		{
			AggregateId = aggregateId;
			DomainEvents = new Collection<IEventData>();
		}
	}
}