using System;
using System.Collections.Generic;
using DNIC.Erechtheion.Application.Dto.Reply;
using DNIC.Erechtheion.Domain.Entities;

namespace DNIC.Erechtheion.Domain.Repositories
{
	public interface IReplyRepository
	{
		Reply Get(Guid aggregateId);

		int Create(Reply reply);

		int Delete(Reply reply);

		int Update(Reply reply);

		(IEnumerable<Reply> records, int count) Search(ReplyCondition condition);
	}
}