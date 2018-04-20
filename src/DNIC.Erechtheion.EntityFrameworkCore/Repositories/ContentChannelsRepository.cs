using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.EntityFrameworkCore.Repositories
{
	public class ContentChannelsRepository : EfCoreRepositoryBase<ContentChannels>, IContentChannelsRepository
	{
		public ContentChannelsRepository(ErechtheionDbContext dbContext) : base(dbContext)
		{
		}
	}
}
