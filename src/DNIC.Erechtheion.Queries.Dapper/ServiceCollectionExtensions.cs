using System;
using System.Linq;
using System.Reflection;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Sql;
using DNIC.Erechtheion.QuerySerivces.QueryServices;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.Queries.Dapper
{
	public static class ServiceCollectionExtensions
	{
		public static void UseDapperQueries(this IErechtheionBuilder builder)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var sqlMaps = assembly.GetManifestResourceNames().Where(r => r.Contains("SqlMaps"));
			var streams = sqlMaps.Select(s => assembly.GetManifestResourceStream(s));
			foreach (var stream in streams)
			{
				SqlMap.Instance.Load(stream);
			}
			builder.Services.AddScoped<ITopicQuerySerivce, TopicQueryService>();
		}
	}
}