using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace DNIC.Erechtheion.Controllers
{
	[Route("topic")]
	public class TopicController : BaseController
	{
		private readonly ITopicApplicationService _topicApplicationService;

		public TopicController(IErechtheionConfiguration erechtheionConfiguration, ITopicApplicationService topicApplicationService) : base(erechtheionConfiguration)
		{
			_topicApplicationService = topicApplicationService;
		}

		[HttpGet("")]
		public async Task<IEnumerable<TopicOutput>> GetAll()
		{
			return await _topicApplicationService.GetAllListAsync();
		}

		[HttpGet("{id}")]
		public async Task<TopicOutput> Get(int id)
		{
			return await _topicApplicationService.GetAsync(id);
		}

		public async Task<TopicOutput> Create(string name)
		{
			return await _topicApplicationService.CreateAsync(name);
		}

		public async Task<TopicOutput> Change(int id, string name)
		{
			return await _topicApplicationService.ChangeAsync(id, name);
		}
	}
}