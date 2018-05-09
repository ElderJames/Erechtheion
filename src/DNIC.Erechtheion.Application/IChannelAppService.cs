using DNIC.Erechtheion.Application.Dto;
using DNIC.Erechtheion.Core.AppServiceBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNIC.Erechtheion.Application
{
	public interface IChannelAppService : IApplicationService
	{
		Task CreateChannelAsync(CreateChannelDto input);
	}
}
