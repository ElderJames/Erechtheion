using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartSql;
using SmartSql.Abstractions;

namespace DNIC.Erechtheion.SmartSql
{
	public static class ServiceCollectionExtensions
	{
		public static void AddSmartSql(this IServiceCollection services, Action<SmartSqlOptions> configureOptions)
		{
			var options = new SmartSqlOptions();
			configureOptions(options);

			services.AddSingleton(serviceProvider =>
			{
				var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
				return MapperContainer.Instance.GetSqlMapper(loggerFactory, string.Empty, new NativeConfigLoader(options));
			});

			services.AddSingleton<ISmartSqlMapperAsync>(serviceProvider => serviceProvider.GetRequiredService<ISmartSqlMapper>());
		}
	}
}