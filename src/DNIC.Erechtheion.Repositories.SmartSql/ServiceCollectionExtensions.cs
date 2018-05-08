using System;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.SmartSql;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.Repositories.SmartSql
{
	public static class ServiceCollectionExtensions
	{
		public static void UseSmartSqlRepositories(this IErechtheionBuilder builder, Action<SmartSqlOptions> optionAction)
		{
			var services = builder.Services;
			services.AddSmartSql(optionAction);

			services.AddScoped<ITopicRepository, TopicRepository>();
		}
	}
}