using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Conditions;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DNIC.Erechtheion.EntityFrameworkCore.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TopicRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Topic topic)
        {
            var entity = await _dbContext.Message.AddAsync(topic);
            await _dbContext.SaveChangesAsync();
            return entity.Entity.Id > 0;
        }

        public async Task<bool> Update(Topic topic)
        {
            _dbContext.Message.Update(topic);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Topic> GetById(long id)
        {
            return await _dbContext.Message.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Topic>> FindList(TopicSearch search)
        {
            var query = _dbContext.Message.AsQueryable();
            if (search.BeginTime.HasValue)
                query = query.Where(t => t.CreationTime >= search.BeginTime.Value);
            if (search.EndTime.HasValue)
                query = query.Where(t => t.CreationTime < search.EndTime.Value);

            return await query.ToListAsync();
        }

        public async Task<PagedData<Topic>> Search(TopicSearch search)
        {
            var query = _dbContext.Message.AsQueryable();
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