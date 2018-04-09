using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Topic;
using DNIC.Erechtheion.Application.Topic.Dto;
using DNIC.Erechtheion.Core.Configuration;

namespace DNIC.Erechtheion.Controllers
{
	public class TopicController : BaseController
	{
		private readonly ITopicApplicationService _topicApplicationService;

		public TopicController(IErechtheionConfiguration erechtheionConfiguration, ITopicApplicationService topicApplicationService) : base(erechtheionConfiguration)
		{
			_topicApplicationService = topicApplicationService;
		}

		public async Task<IEnumerable<TopicOutput>> GetAll()
		{
			return await _topicApplicationService.GetAll();
		}
	}
}