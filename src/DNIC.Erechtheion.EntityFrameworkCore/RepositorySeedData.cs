using DNIC.Erechtheion.Core.Configuration;
using DNIC.Erechtheion.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using DNIC.Erechtheion.Core.EnumTypes;
using DNIC.Erechtheion.Domain.Aggregates;

namespace DNIC.Erechtheion.EntityFrameworkCore
{
	public class RepositorySeedData : IRepositorySeedData
	{
		private readonly IServiceProvider serviceProvider;

		public RepositorySeedData(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public void EnsureSeedData()
		{
			Console.WriteLine("Seeding database...");
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

				using (var context = scope.ServiceProvider.GetRequiredService<ErechtheionDbContext>())
				{
					context.Database.Migrate();
					if (!context.Topic.Any())
					{
						var topic = new Topic(Guid.NewGuid(), 123456789L, Guid.NewGuid(), "Hello World", "hello-word", ContentTypes.Html, "I'm Iron man", SubjectStates.草稿);
						var topic2 = new Topic(Guid.NewGuid(), 123456789L, Guid.NewGuid(), "Hello World", "hello-word", ContentTypes.Html, "I'm Iron man", SubjectStates.草稿);
						context.Topic.Add(topic);
						context.Topic.Add(topic2);
						context.SaveChanges();
					}
				}
			}

			Console.WriteLine("Done seeding database.");
			Console.WriteLine();
		}
	}
}