using DNIC.Erechtheion.Application.Topic.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DNIC.Erechtheion.Application.Topic
{
	public interface ITopicApplicationService
	{
		Task<TopicOutput> GetById(long id);
		Task<IEnumerable<TopicOutput>> GetAll();
	}
}