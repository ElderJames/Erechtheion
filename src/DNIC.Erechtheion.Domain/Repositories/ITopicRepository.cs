using System.Collections.Generic;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Conditions;
using DNIC.Erechtheion.Domain.Entities;

namespace DNIC.Erechtheion.Domain.Repositories
{
    public interface ITopicRepository
    {
        Task<Topic> GetById(long id);

        Task<IEnumerable<Topic>> FindList(TopicSearch search);

        Task<PagedData<Topic>> Search(TopicSearch search);
    }
}