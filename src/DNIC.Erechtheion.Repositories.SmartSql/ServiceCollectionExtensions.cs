using System;
using System.Reflection;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.SmartSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartSql;

namespace DNIC.Erechtheion.Repositories.SmartSql
{
	public static class ServiceCollectionExtensions
	{
		public static void UseSmartSqlRepositories(this IErechtheionBuilder builder, Action<SmartSqlOptions> configureOptions)
		{
			var options = new SmartSqlOptions();
			configureOptions(options);
			var services = builder.Services;
		
			var assembly = Assembly.GetExecutingAssembly();
			services.AddSingleton(serviceProvider =>
			{
				var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
				var configLoader = new NativeConfigLoader( options);
				configLoader.SetAssemblyOf(assembly);
				return new RepositorySqlMapper(new SmartSqlMapper(loggerFactory, configureOptions.GetType().AssemblyQualifiedName, configLoader));
			});

			services.AddScoped<ITopicRepository, TopicRepository>();
		}
	}
}