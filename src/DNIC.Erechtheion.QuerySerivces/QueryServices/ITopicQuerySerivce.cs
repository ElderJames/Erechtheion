using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;

namespace DNIC.Erechtheion.QuerySerivces.QueryServices
{
	public interface ITopicQuerySerivce
	{
		Task<TopicOutput> Get(int id);

		Task<IEnumerable<TopicOutput>> GetAll();
	}
}