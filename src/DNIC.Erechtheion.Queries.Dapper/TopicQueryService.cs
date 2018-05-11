using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.QuerySerivces.QueryServices;
using Dapper;
using DNIC.Erechtheion.Core.Sql;
using DNIC.Erechtheion.Core.Configuration;

namespace DNIC.Erechtheion.Queries.Dapper
{
	public class TopicQueryService : BaseQueryService, ITopicQuerySerivce
	{
		public TopicQueryService(DbProviderFactory dbProviderFactory, IErechtheionConfiguration configuration) : base(dbProviderFactory, configuration)
		{
		}

		public async Task<TopicOutput> Get(int id)
		{
			using (var conn = GetDbConnection())
			{
				return await conn.QueryFirstAsync<TopicOutput>(SqlMap.Instance["topic", "queryById"], new { Id = id });
			}
		}

		public async Task<IEnumerable<TopicOutput>> GetAll()
		{
			using (var conn = GetDbConnection())
			{
				return await conn.QueryAsync<TopicOutput>(SqlMap.Instance["topic", "queryAll"]);
			}
		}
	}
}