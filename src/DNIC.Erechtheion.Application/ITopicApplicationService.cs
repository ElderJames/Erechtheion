using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;

namespace DNIC.Erechtheion.Application
{
	public interface ITopicApplicationService
	{
		Task<TopicOutput> GetById(long id);

		Task<IEnumerable<TopicOutput>> GetAll();

		Task<TopicOutput> Create(string name);

		Task<TopicOutput> Change(long id, string name);
	}
}