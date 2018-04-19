using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain
{
	public interface IAggregateRoot : IAggregateRoot<int>, IEntity
	{

	}

	public interface IAggregateRoot<TPrimaryKey> : IEntity<TPrimaryKey>
	{
	}
}
