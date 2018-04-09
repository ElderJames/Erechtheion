using DNIC.Erechtheion.Application.Topic;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNIC.Erechtheion.Application.Service.Topic;
using DNIC.Erechtheion.EntityFrameworkCore;
using DNIC.Erechtheion.Domain;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.EntityFrameworkCore.Repositories;

namespace DNIC.Erechtheion
{
	public class DependencyInjectionConfig
	{
		public static void Inject(IServiceCollection services)
		{
			services.AddSingleton<IErechtheionConfiguration, ErechtheionConfiguration>();
			services.AddSingleton<IRepositorySeedData, RepositorySeedData>();
			services.AddScoped<ITopicRepository, TopicRepository>();
			services.AddScoped<ITopicApplicationService, TopicApplicationService>();
		}
	}
}