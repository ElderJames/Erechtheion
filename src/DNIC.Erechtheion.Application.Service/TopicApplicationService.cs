using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.Core.EnumTypes;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.Domain.ValueObjects;

namespace DNIC.Erechtheion.Application.Service
{
	public class TopicApplicationService : ApplicationServiceBase, ITopicApplicationService
	{
		private readonly ITopicRepository _topicRepository;

		public TopicApplicationService(IErechtheionConfiguration configuration, ITopicRepository topicRepository) : base(configuration)
		{
			_topicRepository = topicRepository;
		}

		public async Task<IEnumerable<TopicOutput>> GetAllListAsync()
		{
			var topics = await _topicRepository.GetAllListAsync();
			return AutoMapper.Mapper.Map<IEnumerable<TopicOutput>>(topics);
		}

		public async Task<TopicOutput> GetAsync(int id)
		{
			var topic = await _topicRepository.GetAsync(id);
			return AutoMapper.Mapper.Map<Topic, TopicOutput>(topic);
		}

		public async Task<TopicOutput> CreateAsync(string name)
		{
			var topic = new Topic(Guid.NewGuid(), name, "hello-word", new List<ContentChannels>(), ContentType.Html, "I'm Iron man", ContentState.草稿);

			return AutoMapper.Mapper.Map<Topic, TopicOutput>(topic);
		}

		public async Task<TopicOutput> ChangeAsync(int id, string name)
		{
			var topic = new Topic(Guid.NewGuid(), name, "hello-word", new List<ContentChannels>(), ContentType.Html, "I'm Iron man", ContentState.草稿);

			return AutoMapper.Mapper.Map<Topic, TopicOutput>(topic);
		}
	}
}