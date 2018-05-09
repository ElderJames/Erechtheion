using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartSql;
using SmartSql.Abstractions;

namespace DNIC.Erechtheion.SmartSql
{
	public static class ServiceCollectionExtensions
	{
		public static void AddSmartSql(this IServiceCollection services, Action<SmartSqlOptions> optionAction)
		{
			var options = new SmartSqlOptions();
			optionAction(options);

			services.AddSingleton(sp =>
			{
				var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
				return MapperContainer.Instance.GetSqlMapper(loggerFactory, string.Empty, new NativeConfigLoader(loggerFactory, options));
			});

			services.AddSingleton<ISmartSqlMapperAsync>(sp => sp.GetRequiredService<ISmartSqlMapper>());
		}
	}
}