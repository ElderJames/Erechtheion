using DNIC.Erechtheion.Application;
using DNIC.Erechtheion.Application.Service;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DNIC.Erechtheion.EntityFrameworkCore;
using DNIC.Erechtheion.Domain;
using DNIC.Erechtheion.Domain.Topic;
using DNIC.Erechtheion.EntityFrameworkCore.Repositories;

namespace DNIC.Erechtheion
{
	public static class DependencyInjectionConfig
	{
		public static void AddErechtheion(this IServiceCollection services)
		{
			services.AddSingleton<IErechtheionConfiguration, ErechtheionConfiguration>();
			services.AddSingleton<IRepositorySeedData, RepositorySeedData>();
			services.AddScoped<ITopicRepository, TopicRepository>();
			services.AddScoped<ITopicApplicationService, TopicApplicationService>();
			services.AddScoped<TopicDomainService>();
		}
	}
}