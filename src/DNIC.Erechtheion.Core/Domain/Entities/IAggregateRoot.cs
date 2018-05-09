﻿namespace DNIC.Erechtheion.Core.Domain.Entities
{
	public interface IAggregateRoot : IAggregateRoot<int>, IEntity
	{

	}

	public interface IAggregateRoot<TPrimaryKey> : IEntity<TPrimaryKey>
	{
	}
}
