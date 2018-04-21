using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using DNIC.Erechtheion.Application.EnumTypes;
using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.ValueObjects;

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
					if (!context.Topics.Any())
					{
						var topic = new Topic(Guid.NewGuid(), "Hello World", "hello-word", new List<ContentChannels>(), ContentType.Html, "I'm Iron man", ContentState.草稿);
						var topic2 = new Topic(Guid.NewGuid(), "Hello World", "hello-word", new List<ContentChannels>(), ContentType.Html, "I'm Iron man", ContentState.草稿);
						context.Topics.Add(topic);
						context.Topics.Add(topic2);
						context.SaveChanges();
					}
				}
			}

			Console.WriteLine("Done seeding database.");
			Console.WriteLine();
		}
	}
}