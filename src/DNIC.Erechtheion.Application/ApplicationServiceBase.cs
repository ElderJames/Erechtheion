using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Application
{
	public abstract class ApplicationServiceBase
	{
		protected readonly IErechtheionConfiguration Configuration;
		protected readonly ApplicationDbContext DbContext;
		protected readonly ILogger Logger;

		protected ApplicationServiceBase(ApplicationDbContext dbcontext, IErechtheionConfiguration configuration, ILoggerFactory loggerFactory)
		{
			DbContext = dbcontext;
			Configuration = configuration;
 
			Logger = loggerFactory.CreateLogger(GetType());
		}
	}
}
