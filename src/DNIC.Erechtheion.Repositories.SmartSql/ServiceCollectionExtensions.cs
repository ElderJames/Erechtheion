using System;
using System.Linq;
using System.Reflection;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Sql;
using DNIC.Erechtheion.Domain.Repositories;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace DNIC.Erechtheion.Repositories.Dapper
{
	public static class ServiceCollectionExtensions
	{
		public static void UseDapperRepositories(this IErechtheionBuilder builder)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var sqlMaps = assembly.GetManifestResourceNames().Where(r => r.Contains("SqlMaps"));
			var streams = sqlMaps.Select(s => assembly.GetManifestResourceStream(s));
			foreach (var stream in streams)
			{
				SqlMap.Instance.Load(stream);
			}

			builder.Services.AddScoped<ITopicRepository, TopicRepository>();
		}
	}
}