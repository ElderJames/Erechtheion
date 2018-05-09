using System.Threading.Tasks;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using SmartSql.Abstractions;

namespace DNIC.Erechtheion.Repositories.SmartSql
{
	public class TopicRepository : ITopicRepository
	{
		private readonly RepositorySqlMapper _sqlMapper;

		public TopicRepository(RepositorySqlMapper sqlMapper)
		{
			_sqlMapper = sqlMapper;
		}

		public async Task<int> CreateAsync(Topic topic)
		{
			return await _sqlMapper.SmartSqlMapper.ExecuteAsync(new RequestContext { Scope = "Topic", SqlId = "Create", Request = topic });
		}

		public async Task<int> DeleteAsync(Topic topic)
		{
			return await _sqlMapper.SmartSqlMapper.ExecuteAsync(new RequestContext());
		}

		public Task<int> UpdateAsync(Topic topic)
		{
			throw new System.NotImplementedException();
		}
	}
}