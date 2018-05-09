using System;
using System.Reflection;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.QuerySerivces.QueryServices;
using DNIC.Erechtheion.SmartSql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartSql;

namespace DNIC.Erechtheion.Queries.SmartSql
{
	public static class ServiceCollectionExtensions
	{
		public static void UseSmartSqlQueries(this IErechtheionBuilder builder, Action<SmartSqlOptions> optionAction)
		{
			var options = new SmartSqlOptions();
			optionAction(options);
			var services = builder.Services;
			//services.AddSmartSql(optionAction);
			var assembly = Assembly.GetExecutingAssembly();
			services.AddSingleton(sp =>
			{
				var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
				var configLoader = new NativeConfigLoader(options);

				configLoader.SetAssemblyOf(assembly);
				return new QueriesSqlMapper(new SmartSqlMapper(loggerFactory, optionAction.GetType().AssemblyQualifiedName, configLoader));
			});

			services.AddScoped<ITopicQuerySerivce, TopicQueryService>();
		}
	}
}