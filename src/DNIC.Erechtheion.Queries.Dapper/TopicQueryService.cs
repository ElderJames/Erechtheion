using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.QuerySerivces.QueryServices;
using Dapper;
using DNIC.Erechtheion.Core.Sql;

namespace DNIC.Erechtheion.Queries.Dapper
{
	public class TopicQueryService : ITopicQuerySerivce
	{
		private readonly DbProviderFactory _dbProviderFactory;

		public TopicQueryService(DbProviderFactory dbProviderFactory)
		{
			_dbProviderFactory = dbProviderFactory;
		}

		public async Task<TopicOutput> Get(int id)
		{
			using (var conn = _dbProviderFactory.CreateConnection())
			{
				return await conn.QueryFirstAsync<TopicOutput>(SqlMap.Instance["topic", "queryById"], new { Id = id });
			}
		}

		public async Task<IEnumerable<TopicOutput>> GetAll()
		{
			using (var conn = _dbProviderFactory.CreateConnection())
			{
				return await conn.QueryAsync<TopicOutput>(SqlMap.Instance["topic", "queryAll"]);
			}
		}
	}
}