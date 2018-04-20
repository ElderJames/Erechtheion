using DNIC.Erechtheion.Core;
using System;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.EntityFrameworkCore
{
	public static class ServiceCollectionExtensions
	{
		public static void UseEntityFrameworkCore(this IErechtheionBuilder builder, Action<DbContextOptionsBuilder> optionAction)
		{
			var services = builder.Services;

			services.AddEntityFrameworkSqlServer()
				.AddDbContext<ErechtheionDbContext>(optionAction);

			services.AddSingleton<ISeedDataInitiator, SeedDataInitiator>();

			//仓储
			services.AddScoped<ITopicRepository, TopicRepository>();
			services.AddScoped<IChannelRepository, ChannelRepository>();
			services.AddScoped<IContentChannelsRepository, ContentChannelsRepository>();
		}
	}
}