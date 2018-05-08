using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto.Topic;
using DNIC.Erechtheion.Core.Domain.Repositories;
using DNIC.Erechtheion.Core.DtoBase;
using DNIC.Erechtheion.Domain.Entities;

namespace DNIC.Erechtheion.Domain.Repositories
{
	public interface ITopicRepository
	{
		Task<Topic> Get(int id);

		Task<Topic> Get(Guid id);

		Task<(IEnumerable<Topic> records, int count)> Search(TopicCondition condition);

		Task<IEnumerable<Topic>> GetAll();
	}
}