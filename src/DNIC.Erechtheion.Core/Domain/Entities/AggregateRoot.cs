using DNIC.Erechtheion.Core.EventBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain.Entities
{
	public class AggregateRoot : AggregateRoot<int>, IAggregateRoot
	{
	}

	public class AggregateRoot<TPrimaryKey> : Entity<TPrimaryKey>, IAggregateRoot<TPrimaryKey>
	{
		public virtual ICollection<IEventData> DomainEvents { get; }

		public AggregateRoot()
		{
			DomainEvents = new Collection<IEventData>();
		}
	}
}
