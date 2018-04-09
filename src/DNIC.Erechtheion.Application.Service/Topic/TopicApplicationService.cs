using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Topic;
using DNIC.Erechtheion.Application.Topic.Dto;
using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace DNIC.Erechtheion.Application.Service.Topic
{
	public class TopicApplicationService : ApplicationServiceBase, ITopicApplicationService
	{
		private readonly ITopicRepository _topicRepository;

		public TopicApplicationService(IErechtheionConfiguration configuration, ILoggerFactory loggerFactory, ITopicRepository topicRepository) : base(configuration, loggerFactory)
		{
			_topicRepository = topicRepository;
		}

		public async Task<IEnumerable<TopicOutput>> GetAll()
		{
			var topics = await _topicRepository.GetAll();
			if (topics == null)
			{
				return null;
			}
			return AutoMapper.Mapper.Map<IEnumerable<TopicOutput>>(topics);
		}

		public async Task<TopicOutput> GetById(long id)
		{
			var topic = await _topicRepository.GetById(id);
			if (topic == null)
			{
				return null;
			}

			return AutoMapper.Mapper.Map<Domain.Entities.Topic, TopicOutput>(topic);
		}
	}
}