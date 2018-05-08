using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Application.EnumTypes;
using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.Domain.ValueObjects;
using AutoMapper;
using DNIC.Erechtheion.Application.QueryServices;

namespace DNIC.Erechtheion.Application.Services
{
	public class TopicApplicationService : ApplicationServiceBase, ITopicApplicationService
	{
		private readonly ITopicRepository _topicRepository;
		private ITopicQuerySerivce _topicQuerySerivce;

		public TopicApplicationService(IErechtheionConfiguration configuration, ITopicRepository topicRepository, ITopicQuerySerivce topicQuerySerivce) : base(configuration)
		{
			_topicRepository = topicRepository;
			_topicQuerySerivce = topicQuerySerivce;
		}

		public async Task<IEnumerable<TopicOutput>> GetAllListAsync()
		{
			var topics = await _topicQuerySerivce.GetAll();
			return topics;
		}

		public async Task<TopicOutput> GetAsync(int id)
		{
			var topic = await _topicQuerySerivce.Get(id);
			return topic;
		}

		public async Task<TopicOutput> CreateAsync(string name)
		{
			var topic = new Topic(Guid.NewGuid(), name, "hello-word", new List<ContentChannels>(), ContentType.Html, "I'm Iron man", ContentState.草稿);
			if (await _topicRepository.CreateAsync(topic) <= 0)
				return null;

			return Mapper.Map<Topic, TopicOutput>(topic);
		}

		public async Task<TopicOutput> ChangeAsync(int id, string name)
		{
			var topic = new Topic(Guid.NewGuid(), name, "hello-word", new List<ContentChannels>(), ContentType.Html, "I'm Iron man", ContentState.草稿);
			if (await _topicRepository.UpdateAsync(topic) <= 0)
				return null;

			return Mapper.Map<Topic, TopicOutput>(topic);
		}
	}
}