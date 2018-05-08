using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Application.QueryServices;
using SmartSql.Abstractions;

namespace DNIC.Erechtheion.QuerySerivces.SmartSql
{
	public class TopicQueryService : ITopicQuerySerivce
	{
		private readonly ISmartSqlMapper _sqlMapper;

		public TopicQueryService(ISmartSqlMapper sqlMapper)
		{
			_sqlMapper = sqlMapper;
		}

		public async Task<TopicOutput> Get(int id)
		{
			return await _sqlMapper.QuerySingleAsync<TopicOutput>(new RequestContext()
			{
				Scope = "Topic",
				SqlId = "QueryTopic",
				Request = new { Id = id }
			});
		}

		public async Task<IEnumerable<TopicOutput>> GetAll()
		{
			return await _sqlMapper.QueryAsync<TopicOutput>(new RequestContext()
			{
				Scope = "Topic",
				SqlId = "QueryTopic",
				Request = new { }
			});
		}
	}
}