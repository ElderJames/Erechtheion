using System.Data.Common;
using System.Threading.Tasks;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using Dapper;
using DNIC.Erechtheion.Core.Sql;

namespace DNIC.Erechtheion.Repositories.Dapper
{
	public class TopicRepository : ITopicRepository
	{
		private readonly DbProviderFactory _dbProviderFactory;

		public TopicRepository(DbProviderFactory dbProviderFactory)
		{
			_dbProviderFactory = dbProviderFactory;
		}

		public async Task<int> CreateAsync(Topic topic)
		{
			using (var conn = _dbProviderFactory.CreateConnection())
			{
				return await conn.ExecuteAsync(SqlMap.Instance["topic", "create"], topic);
			}
		}

		public async Task<int> DeleteAsync(Topic topic)
		{
			using (var conn = _dbProviderFactory.CreateConnection())
			{
				return await conn.ExecuteAsync(SqlMap.Instance["topic", "delete"], topic);
			}
		}

		public async Task<int> UpdateAsync(Topic topic)
		{
			using (var conn = _dbProviderFactory.CreateConnection())
			{
				return await conn.ExecuteAsync(SqlMap.Instance["topic", "update"], topic);
			}
		}
	}
}