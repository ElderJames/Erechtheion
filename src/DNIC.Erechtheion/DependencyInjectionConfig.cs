using DNIC.Erechtheion.Application.Topic;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNIC.Erechtheion
{
	public class DependencyInjectionConfig
	{
		public static void Inject(IServiceCollection services)
		{
			services.AddSingleton<IErechtheionConfiguration, ErechtheionConfiguration>();
			services.AddSingleton<ITopicApplicationService, TopicApplicationService>();
		}
	}
}
