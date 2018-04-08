using System;
using System.Collections.Generic;
using System.Text;
using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DNIC.Erechtheion.Application.Topic
{
	public class TopicApplicationService : ApplicationServiceBase, ITopicApplicationService
	{
		protected TopicApplicationService(ApplicationDbContext dbcontext, IErechtheionConfiguration configuration, ILoggerFactory loggerFactory) : base(dbcontext, configuration, loggerFactory)
		{
		}
	}
}
