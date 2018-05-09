using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.QuerySerivces.QueryServices;
using SmartSql.Abstractions;

namespace DNIC.Erechtheion.Queries.SmartSql
{
	public class TopicQueryService : ITopicQuerySerivce
	{
		private readonly ISmartSqlMapper _sqlMapper;

		public TopicQueryService(QueriesSqlMapper queryServiceSqlMapper)
		{
			_sqlMapper = queryServiceSqlMapper.SmartSqlMapper;
		}

		public async Task<TopicOutput> Get(int id)
		{
			return await _sqlMapper.QuerySingleAsync<TopicOutput>(new RequestContext
			{
				Scope = "Topic",
				SqlId = "QueryTopic",
				Request = new { Id = id }
			});
		}

		public async Task<IEnumerable<TopicOutput>> GetAll()
		{
			return await _sqlMapper.QueryAsync<TopicOutput>(new RequestContext
			{
				Scope = "Topic",
				SqlId = "QueryTopic",
				Request = new { }
			});
		}
	}
}