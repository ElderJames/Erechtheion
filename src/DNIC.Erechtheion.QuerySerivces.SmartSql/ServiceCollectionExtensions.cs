using System;
using DNIC.Erechtheion.Application.QueryServices;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.SmartSql;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.QuerySerivces.SmartSql
{
	public static class ServiceCollectionExtensions
	{
		public static void UseSmartSqlQueryServices(this IErechtheionBuilder builder, Action<SmartSqlOptions> optionAction)
		{
			var services = builder.Services;
			services.AddSmartSql(optionAction);

			services.AddScoped<ITopicQuerySerivce, TopicQueryService>();
		}
	}
}