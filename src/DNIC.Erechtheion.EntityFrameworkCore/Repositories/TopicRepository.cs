using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Conditions;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;

namespace DNIC.Erechtheion.EntityFrameworkCore.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        public Task<Topic> GetById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Topic>> FindList(TopicSearch search)
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedData<Topic>> Search(TopicSearch search)
        {
            throw new System.NotImplementedException();
        }
    }
}