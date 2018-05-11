using System;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.Application.Services
{
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// 注册应用服务所需组件
		/// </summary>
		/// <param name="services"></param>
		/// <param name="builderAction"></param>
		public static void AddErechtheionServices(this IErechtheionBuilder builder)
		{
			AutoMapperExtensions.Initialize();

			builder.Services.AddTransient<ITopicAppService, TopicAppService>();
			builder.Services.AddTransient<IChannelAppService, ChannelAppService>();
		}
	}
}