using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.Core.DtoBase;
using DNIC.Erechtheion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace DNIC.Erechtheion.EntityFrameworkCore.Repositories
{
	public class TopicRepository : ITopicRepository
	{
		private ErechtheionDbContext dbContext;

		public TopicRepository(ErechtheionDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<Topic> Get(int id)
		{
			return await dbContext.Topics.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Topic>> GetAll()
		{
			return await dbContext.Topics.ToListAsync();
		}
	}
}