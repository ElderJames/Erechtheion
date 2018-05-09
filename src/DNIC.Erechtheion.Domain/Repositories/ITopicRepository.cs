using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core.Domain.Repositories;
using DNIC.Erechtheion.Domain.Entities;

namespace DNIC.Erechtheion.Domain.Repositories
{
	public interface ITopicRepository : IRepository
	{
		Task<Topic> Get(int id);

		Task<IEnumerable<Topic>> GetAll();
	}
}