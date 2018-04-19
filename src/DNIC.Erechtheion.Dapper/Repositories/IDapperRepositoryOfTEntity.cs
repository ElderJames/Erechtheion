using DNIC.Erechtheion.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Dapper.Repositories
{
	public interface IDapperRepository<TEntity> : IDapperRepository<TEntity, int> where TEntity : class, IEntity<int>
	{
	}
}
