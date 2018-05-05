using System;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.SmartSql.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MapperContainer = SmartSql.MapperContainer;

namespace DNIC.Erechtheion.SmartSql
{
	public static class ServiceCollectionExtensions
	{
		public static void UseSmartSql(this IErechtheionBuilder builder, Action<SmartSqlOptions> optionAction)
		{
			var services = builder.Services;
			var options = new SmartSqlOptions();
			optionAction(options);

			services.AddSingleton(sp =>
			{
				var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
				return MapperContainer.Instance.GetSqlMapper(loggerFactory, string.Empty, new NativeConfigLoader(loggerFactory, options));
			});

			services.AddScoped<ITopicRepository, TopicRepository>();
		}
	}
}