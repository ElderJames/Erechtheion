using System;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.Identity.EntityFrameworkCore
{
	public class IdentitySeedDataInitiator : ISeedDataInitiator
	{
		private readonly IServiceProvider serviceProvider;

		public IdentitySeedDataInitiator(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public void EnsureSeedData()
		{
			Console.WriteLine("Seeding identity database...");
			var configuration = serviceProvider.GetRequiredService<IErechtheionConfiguration>();

			using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				if ((configuration.AuthenticationMode & AuthenticationMode.Self) == AuthenticationMode.Self)
				{
					using (var context = scope.ServiceProvider.GetRequiredService<ErechtheionIdentityDbContext>())
					{
						context.Database.Migrate();
					}
				}
			}

			Console.WriteLine("Done seeding identity database.");
			Console.WriteLine();
		}
	}
}