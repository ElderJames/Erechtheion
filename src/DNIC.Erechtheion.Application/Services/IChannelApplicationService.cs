using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Core.Services;

namespace DNIC.Erechtheion.Application.Services
{
	public interface IChannelApplicationService : IApplicationService
	{
		Task CreateChannelAsync(CreateChannelDto input);
	}
}