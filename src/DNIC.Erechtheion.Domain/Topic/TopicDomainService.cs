using System.Threading.Tasks;

namespace DNIC.Erechtheion.Domain.Topic
{
	public class TopicDomainService
	{
		private readonly ITopicRepository _topicRepository;

		public TopicDomainService(ITopicRepository topicRepository)
		{
			_topicRepository = topicRepository;
		}

		public async Task<Topic> CreateTopic(string topicName)
		{
			var topic = new Topic(topicName);
			return await _topicRepository.Create(topic);
		}

		public async Task<Topic> ChangeTopic(long id, string topicName)
		{
			var topic = await _topicRepository.GetById(id);
			if (topic == null)
				return null;

			topic.Change(topicName);

			if (await _topicRepository.Update(topic))
				return topic;

			return null;
		}
	}
}