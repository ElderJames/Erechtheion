using DNIC.Erechtheion.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using DNIC.Erechtheion.Core;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DNIC.Erechtheion.Repositories.Dapper;
using DNIC.Erechtheion.Queries.Dapper;
using System;

namespace DNIC.Erechtheion.Tests
{
	public abstract class TestBase
	{
		protected IServiceProvider ServiceProvider { get; private set; }

		protected TestBase()
		{
			var configurationFile = $"appsettings.json";
			IConfigurationBuilder builder = new ConfigurationBuilder()
				.AddJsonFile(configurationFile, optional: true, reloadOnChange: true);

			var Configuration = builder.Build();

			var services = new ServiceCollection();
			services.AddErechtheion(config =>
			{
				config.UseConfiguration(Configuration);
				config.UseDbProviderFactory(SqlClientFactory.Instance);
				config.UseDapperRepositories();
				config.UseDapperQueries();
			});
			ServiceProvider = services.BuildServiceProvider();
		}
	}
}