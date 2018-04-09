using System.Threading.Tasks;
using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.Core.Response;
using DNIC.Erechtheion.Core.Services;
using DNIC.Erechtheion.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace DNIC.Erechtheion.Application.Topic
{
    public class TopicApplicationService : ApplicationServiceBase, ITopicApplicationService
    {
        private readonly ITopicRepository _topicRepository;

        protected TopicApplicationService(IErechtheionConfiguration configuration, ILoggerFactory loggerFactory, ITopicRepository topicRepository) : base(configuration, loggerFactory)
        {
            this._topicRepository = topicRepository;
        }

        public async Task<TopicResp> GetById(long id)
        {
            var topic = await _topicRepository.GetById(id);
            if (topic == null)
                return null;

            return AutoMapper.Mapper.Map<Domain.Entities.Topic, TopicResp>(topic);
        }
    }
}