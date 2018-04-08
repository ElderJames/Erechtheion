using System.Threading.Tasks;
using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DNIC.Erechtheion.Application.Topic
{
    public class TopicApplicationService : ApplicationServiceBase, ITopicApplicationService
    {
        private readonly ApplicationDbContext dbcontext;

        protected TopicApplicationService(ApplicationDbContext dbcontext, IErechtheionConfiguration configuration, ILoggerFactory loggerFactory) : base(dbcontext, configuration, loggerFactory)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Domain.Entities.Topic> GetById(long id)
        {
            return await dbcontext.Message.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}