using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.Domain.Topic;

namespace DNIC.Erechtheion.Application.Service
{
	public class TopicApplicationService : ApplicationServiceBase, ITopicApplicationService
	{
		private readonly ITopicRepository _topicRepository;
		private readonly TopicDomainService _topicDomainService;

		public TopicApplicationService(IErechtheionConfiguration configuration, ITopicRepository topicRepository, TopicDomainService topicDomainService) : base(configuration)
		{
			_topicRepository = topicRepository;
			_topicDomainService = topicDomainService;
		}

		public async Task<IEnumerable<TopicOutput>> GetAll()
		{
			var topics = await _topicRepository.GetAll();
			return AutoMapper.Mapper.Map<IEnumerable<TopicOutput>>(topics);
		}

		public async Task<TopicOutput> GetById(long id)
		{
			var topic = await _topicRepository.GetById(id);
			return AutoMapper.Mapper.Map<Topic, TopicOutput>(topic);
		}

		public async Task<TopicOutput> Create(string name)
		{
			var topic = await _topicDomainService.CreateTopic(name);
			return AutoMapper.Mapper.Map<Topic, TopicOutput>(topic);
		}

		public async Task<TopicOutput> Change(long id, string name)
		{
			var topic = await _topicDomainService.ChangeTopic(id, name);
			return AutoMapper.Mapper.Map<Topic, TopicOutput>(topic);
		}
	}
}