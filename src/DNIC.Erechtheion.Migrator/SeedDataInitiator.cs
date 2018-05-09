using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DNIC.Erechtheion.Migrator
{
	public class SeedDataInitiator : ISeedDataInitiator
	{
		private readonly IServiceProvider _serviceProvider;

		public SeedDataInitiator(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void EnsureSeedData()
		{
			InitAccountData();
		}

		private void InitAccountData()
		{
			Console.WriteLine("Seeding identity data...");
			var configuration = _serviceProvider.GetRequiredService<IErechtheionConfiguration>();

			var factory = new DbContextFactory(configuration.ConnectionString);

			if ((configuration.AuthenticationMode & AuthenticationMode.Self) == AuthenticationMode.Self)
			{
				using (var context = factory.CreateDbContext(new string[0]))
				{
					context.Database.Migrate();
				}
			}

			Console.WriteLine("Done seeding identity data.");
			Console.WriteLine();
		}
	}
}
