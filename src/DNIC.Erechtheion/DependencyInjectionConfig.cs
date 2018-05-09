using DNIC.Erechtheion.Application;
using DNIC.Erechtheion.Application.Service;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Migrator;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion
{
	public static class DependencyInjectionConfig
	{
		public static void AddErechtheion(this IServiceCollection services)
		{
			services.AddSingleton<ISeedDataInitiator, SeedDataInitiator>();

			//注册应用服务，如果分离了就注册客户端
			services.AddScoped<ITopicAppService, TopicAppService>();
		}
	}
}