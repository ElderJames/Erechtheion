using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core.Domain.Repositories;
using DNIC.Erechtheion.Core.DtoBase;
using DNIC.Erechtheion.Domain.Entities;

namespace DNIC.Erechtheion.Domain.Repositories
{
	public interface ITopicRepository
	{
		Task<Topic> Get(int id);

		Task<IEnumerable<Topic>> GetAll();
	}
}