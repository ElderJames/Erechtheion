using DNIC.Erechtheion.Core.Configuration;
using Serilog;

namespace DNIC.Erechtheion.Application.Service
{
	public abstract class ApplicationServiceBase
	{
		protected readonly IErechtheionConfiguration Configuration;
		protected readonly ILogger Logger;

		protected ApplicationServiceBase(IErechtheionConfiguration configuration)
		{
			Configuration = configuration;

			Logger = Log.ForContext(GetType());
		}
	}
}