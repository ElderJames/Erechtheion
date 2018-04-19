using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core.Conditions;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.Core.DtoBase;
using DNIC.Erechtheion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace DNIC.Erechtheion.EntityFrameworkCore.Repositories
{
	public class TopicRepository : EfCoreRepositoryBase<Topic>, ITopicRepository
	{
		public TopicRepository(ErechtheionDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<Topic> Create(Topic topic)
		{
			var entity = await Table.AddAsync(topic);
			await DbContext.SaveChangesAsync();
			return entity.Entity;
		}

		public async Task<IEnumerable<Topic>> FindList(TopicSearch search)
		{
			var query = Table.AsQueryable();

			if (!string.IsNullOrEmpty(search.Name))
				query = query.Where(t => t.Title == search.Name);

			if (search.BeginTime.HasValue)
				query = query.Where(t => t.CreationTime >= search.BeginTime.Value);

			if (search.EndTime.HasValue)
				query = query.Where(t => t.CreationTime < search.EndTime.Value);

			return await query.ToListAsync();
		}

		public async Task<PagedModel<Topic>> Search(TopicSearch search)
		{
			var query = Table.AsQueryable();
			if (search.BeginTime.HasValue)
				query = query.Where(t => t.CreationTime >= search.BeginTime.Value);
			if (search.EndTime.HasValue)
				query = query.Where(t => t.CreationTime < search.EndTime.Value);

			var count = await query.CountAsync();
			if (count == 0)
				return new PagedModel<Topic>(search.PageNow, search.PageSize, 0, Enumerable.Empty<Topic>());

			var records = await query.Skip(search.StartIndex).Take(search.PageSize).ToListAsync();

			return new PagedModel<Topic>(search.PageSize, search.PageNow, count, records);
		}
	}
}