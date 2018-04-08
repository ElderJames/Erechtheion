using DNIC.Erechtheion.Core.Configuration;
using Microsoft.Extensions.Logging;

namespace DNIC.Erechtheion.Application
{
    public abstract class ApplicationServiceBase
    {
        protected readonly IErechtheionConfiguration Configuration;
        protected readonly ILogger Logger;

        protected ApplicationServiceBase(IErechtheionConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;

            Logger = loggerFactory.CreateLogger(GetType());
        }
    }
}