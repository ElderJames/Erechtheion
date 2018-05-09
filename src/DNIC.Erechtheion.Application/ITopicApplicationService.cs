using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;

namespace DNIC.Erechtheion.Application
{
	public interface ITopicApplicationService
	{
		Task<TopicOutput> GetAsync(int id);

		Task<IEnumerable<TopicOutput>> GetAllListAsync();

		Task<TopicOutput> CreateAsync(string name);

		Task<TopicOutput> ChangeAsync(int id, string name);
	}
}