using System;
using System.Collections.Generic;
using System.Text;
using DNIC.Erechtheion.Core.Domain.Repositories;
using DNIC.Erechtheion.Domain.Entities;

namespace DNIC.Erechtheion.Domain.Repositories
{
	public interface IReplyRepository : IRepository
	{
		Reply Get(Guid aggregateId);

		int Create(Reply reply);

		int Delete(Reply reply);

		int Update(Reply reply);
	}
}