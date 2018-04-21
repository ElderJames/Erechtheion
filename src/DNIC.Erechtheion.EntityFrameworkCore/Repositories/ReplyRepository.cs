using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;

namespace DNIC.Erechtheion.EntityFrameworkCore.Repositories
{
	public class ReplyRepository : IReplyRepository
	{
		private readonly ErechtheionDbContext _dbContext;

		public ReplyRepository(ErechtheionDbContext dbcontext)
		{
			_dbContext = dbcontext;
		}

		public int Create(Reply reply)
		{
			var entry = _dbContext.Add(reply);
			_dbContext.SaveChanges();
			return entry.Entity.Id;
		}

		public int Delete(Reply reply)
		{
			_dbContext.Replies.Remove(reply);
			return _dbContext.SaveChanges();
		}

		public int Update(Reply reply)
		{
			_dbContext.Update(reply);
			return _dbContext.SaveChanges();
		}
	}
}