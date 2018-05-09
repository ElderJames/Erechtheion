using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using SmartSql.Abstractions;

namespace DNIC.Erechtheion.SmartSql.Repositories
{
	public class TopicRepository : ITopicRepository
	{
		private readonly ISmartSqlMapperAsync _sqlMapper;

		public TopicRepository(ISmartSqlMapperAsync sqlMapper)
		{
			_sqlMapper = sqlMapper;
		}

		public async Task<Topic> Get(int id)
		{
			return await _sqlMapper.QuerySingleAsync<Topic>(new RequestContext()
			{
				Scope = "Topic",
				SqlId = "QueryTopic",
				Request = new { Id = id }
			});
		}

		public async Task<IEnumerable<Topic>> GetAll()
		{
			return await _sqlMapper.QueryAsync<Topic>(new RequestContext()
			{
				Scope = "Topic",
				SqlId = "QueryTopic",
				Request = new { }
			});
		}
	}
}