using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.Domain.Topic;

namespace DNIC.Erechtheion.Application.Service
{
	public class TopicApplicationService : ApplicationServiceBase, ITopicApplicationService
	{
		private readonly ITopicRepository topicRepository;
		private readonly TopicDomainService topicDomainService;

		public TopicApplicationService(IErechtheionConfiguration configuration, ITopicRepository topicRepository, TopicDomainService topicDomainService) : base(configuration)
		{
			this.topicRepository = topicRepository;
			this.topicDomainService = topicDomainService;
		}

		public async Task<IEnumerable<TopicOutput>> GetAll()
		{
			var topics = await topicRepository.GetAll();
			if (topics == null)
			{
				return null;
			}
			return AutoMapper.Mapper.Map<IEnumerable<TopicOutput>>(topics);
		}

		public async Task<TopicOutput> GetById(long id)
		{
			var topic = await topicRepository.GetById(id);
			if (topic == null)
			{
				return null;
			}

			return AutoMapper.Mapper.Map<Domain.Topic.Topic, TopicOutput>(topic);
		}

		public async Task<TopicOutput> Create(string name)
		{
			var topic = await topicDomainService.CreateTopic(name);
			return AutoMapper.Mapper.Map<Domain.Topic.Topic, TopicOutput>(topic);
		}

		public async Task<TopicOutput> Change(long id, string name)
		{
			var topic = await topicDomainService.ChangeTopic(id, name);
			if (topic == null)
				return null;

			return AutoMapper.Mapper.Map<Domain.Topic.Topic, TopicOutput>(topic);
		}
	}
}