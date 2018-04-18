using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Conditions;
using DNIC.Erechtheion.Domain.Aggregates;
using DNIC.Erechtheion.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DNIC.Erechtheion.EntityFrameworkCore.Repositories
{
	public class TopicRepository : ITopicRepository
	{
		private readonly ErechtheionDbContext _dbContext;

		public TopicRepository(ErechtheionDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Topic> Create(Topic topic)
		{
			var entity = await _dbContext.Topic.AddAsync(topic);
			await _dbContext.SaveChangesAsync();
			return entity.Entity;
		}

		public async Task<bool> Update(Topic topic)
		{
			_dbContext.Topic.Update(topic);
			return await _dbContext.SaveChangesAsync() > 0;
		}

		public async Task<Topic> GetById(long id)
		{
			return await _dbContext.Topic.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Topic>> GetAll()
		{
			return await _dbContext.Topic.ToListAsync();
		}

		public async Task<IEnumerable<Topic>> FindList(TopicSearch search)
		{
			var query = _dbContext.Topic.AsQueryable();

			if (!string.IsNullOrEmpty(search.Name))
				query = query.Where(t => t.Title == search.Name);

			if (search.BeginTime.HasValue)
				query = query.Where(t => t.CreationTime >= search.BeginTime.Value);

			if (search.EndTime.HasValue)
				query = query.Where(t => t.CreationTime < search.EndTime.Value);

			return await query.ToListAsync();
		}

		public async Task<PagedData<Topic>> Search(TopicSearch search)
		{
			var query = _dbContext.Topic.AsQueryable();
			if (search.BeginTime.HasValue)
				query = query.Where(t => t.CreationTime >= search.BeginTime.Value);
			if (search.EndTime.HasValue)
				query = query.Where(t => t.CreationTime < search.EndTime.Value);

			var count = await query.CountAsync();
			if (count == 0)
				return new PagedData<Topic>(search.PageNow, search.PageSize, 0, Enumerable.Empty<Topic>());

			var records = await query.Skip(search.StartIndex).Take(search.PageSize).ToListAsync();

			return new PagedData<Topic>(search.PageSize, search.PageNow, count, records);
		}
	}
}