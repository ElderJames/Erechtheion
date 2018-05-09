using DNIC.Erechtheion.Application.Dto;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core.Services;

namespace DNIC.Erechtheion.Application
{
	public interface IChannelAppService : IApplicationService
	{
		Task CreateChannelAsync(CreateChannelDto input);
	}
}
