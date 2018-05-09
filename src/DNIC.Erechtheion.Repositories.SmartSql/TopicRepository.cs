using System.Threading.Tasks;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;

namespace DNIC.Erechtheion.Repositories.SmartSql
{
	public class TopicRepository : ITopicRepository
	{
		public Task<int> CreateAsync(Topic topic)
		{
			throw new System.NotImplementedException();
		}

		public Task<int> DeleteAsync(Topic topic)
		{
			throw new System.NotImplementedException();
		}

		public Task<int> UpdateAsync(Topic topic)
		{
			throw new System.NotImplementedException();
		}
	}
}