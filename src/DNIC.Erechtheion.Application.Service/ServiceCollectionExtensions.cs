using System;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Extensions;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.SmartSql.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.Application.Service
{
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// 注册应用服务所需组件
		/// </summary>
		/// <param name="services"></param>
		/// <param name="builderAction"></param>
		public static void AddErechtheionServices(this IServiceCollection services, Action<IErechtheionBuilder> builderAction)
		{
			AutoMapperExtensions.Initialize();
			var builder = new ErechtheionBuilder(services);
			builderAction(builder);
		}
	}
}