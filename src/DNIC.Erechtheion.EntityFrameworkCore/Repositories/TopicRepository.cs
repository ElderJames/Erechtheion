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
	public class TopicRepository : EfCoreRepositoryBase<Topic>, ITopicRepository
	{
		public TopicRepository(ErechtheionDbContext dbContext) : base(dbContext)
		{
		}
	}
}