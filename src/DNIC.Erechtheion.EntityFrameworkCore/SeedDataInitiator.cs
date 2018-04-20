using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Core.EnumTypes;
using DNIC.Erechtheion.Domain.Entities;

namespace DNIC.Erechtheion.EntityFrameworkCore
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
			Console.WriteLine("Seeding database...");

			using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				using (var context = scope.ServiceProvider.GetRequiredService<ErechtheionDbContext>())
				{
					context.Database.Migrate();
					if (!context.Topic.Any())
					{
						var topic = new Topic("Hello World", "hello-word", ContentType.Html, "I'm Iron man", ContentState.草稿);
						var topic2 = new Topic("Hello World", "hello-word", ContentType.Html, "I'm Iron man", ContentState.草稿);
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