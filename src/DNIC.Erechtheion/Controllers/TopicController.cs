using DNIC.Erechtheion.Application;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Application.Services;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNIC.Erechtheion.Controllers
{
	[Route("topic")]
	public class TopicController : BaseController
	{
		private readonly ITopicAppService _topicApplicationService;

		public TopicController(IErechtheionConfiguration erechtheionConfiguration, ITopicAppService topicApplicationService) : base(erechtheionConfiguration)
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