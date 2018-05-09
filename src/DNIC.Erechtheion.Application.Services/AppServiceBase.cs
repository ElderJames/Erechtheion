using DNIC.Erechtheion.Core.Configuration;
using Serilog;

namespace DNIC.Erechtheion.Application.Services
{
	public abstract class AppServiceBase
	{
		protected readonly IErechtheionConfiguration Configuration;
		protected readonly ILogger Logger;

		protected AppServiceBase(IErechtheionConfiguration configuration)
		{
			Configuration = configuration;

			Logger = Log.ForContext(GetType());
		}
	}
}