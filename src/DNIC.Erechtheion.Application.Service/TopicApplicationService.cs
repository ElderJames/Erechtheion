using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.Core.EnumTypes;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;

namespace DNIC.Erechtheion.Application.Service
{
	public class TopicApplicationService : ApplicationServiceBase, ITopicApplicationService
	{
		private readonly ITopicRepository _topicRepository;

		public TopicApplicationService(IErechtheionConfiguration configuration, ITopicRepository topicRepository) : base(configuration)
		{
			_topicRepository = topicRepository;
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
			var topic = new Topic(Guid.NewGuid(), 123456789L, Guid.NewGuid(), "Hello World", "hello-word", ContentTypes.Html, "I'm Iron man", SubjectStates.草稿);

			return AutoMapper.Mapper.Map<Topic, TopicOutput>(topic);
		}

		public async Task<TopicOutput> Change(long id, string name)
		{
			var topic = new Topic(Guid.NewGuid(), 123456789L, Guid.NewGuid(), "Hello World", "hello-word", ContentTypes.Html, "I'm Iron man", SubjectStates.草稿);

			return AutoMapper.Mapper.Map<Topic, TopicOutput>(topic);
		}
	}
}