using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Migrator
{
	public class SeedDataInitiator : ISeedDataInitiator
	{
		private readonly IServiceProvider serviceProvider;

		public SeedDataInitiator(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public void EnsureSeedData()
		{
			InitAccountData();
		}

		private void InitAccountData()
		{
			Console.WriteLine("Seeding identity data...");
			var configuration = serviceProvider.GetRequiredService<IErechtheionConfiguration>();

			using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				if ((configuration.AuthenticationMode & AuthenticationMode.Self) == AuthenticationMode.Self)
				{
					using (var context = new ErechtheionDbContext(new DbContextOptions<ErechtheionDbContext>()))
					{
						context.Database.Migrate();
					}
				}
			}

			Console.WriteLine("Done seeding identity data.");
			Console.WriteLine();
		}
	}
}
