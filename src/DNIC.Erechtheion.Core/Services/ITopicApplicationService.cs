using System.Threading.Tasks;
using DNIC.Erechtheion.Core.Response;

namespace DNIC.Erechtheion.Core.Services
{
    public interface ITopicApplicationService
    {
        Task<TopicResp> GetById(long id);
    }
}