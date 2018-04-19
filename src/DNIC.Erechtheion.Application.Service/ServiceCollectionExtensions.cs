using System;
using DNIC.Erechtheion.Core;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.Application.Service
{
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		/// 注册仓储等服务所需组件
		/// </summary>
		/// <param name="services"></param>
		public static void AddErechtheionServices(this IServiceCollection services, Action<IErechtheionBuilder> builderAction)
		{
			var builder = new ErechtheionBuilder(services);

			builderAction(builder);

			//配置 TODO:分离后写在服务的Starup.cs
			AutoMapperConfiguration.CreateMap();
		}
	}
}