using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core.Conditions;
using DNIC.Erechtheion.Core.DtoBase;
using DNIC.Erechtheion.Domain.Entities;

namespace DNIC.Erechtheion.Domain.Repositories
{
	public interface ITopicRepository
	{
		Task<Topic> Create(Topic topic);

		Task<bool> Update(Topic topic);

		Task<Topic> GetById(long id);

		Task<IEnumerable<Topic>> GetAll();

		Task<IEnumerable<Topic>> FindList(TopicSearch search);

		Task<PagedModel<Topic>> Search(TopicSearch search);
	}
}