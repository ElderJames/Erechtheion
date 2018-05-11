using System;
using System.Data.Common;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.Core
{
	public class ErechtheionBuilder : IErechtheionBuilder
	{
		private IErechtheionConfiguration _configuration;

		public ErechtheionBuilder(IServiceCollection services)
		{
			Services = services;
		}

		public IServiceCollection Services { get; }

		public IErechtheionConfiguration Configuratoin => _configuration;

		public void UseConfiguration(IConfigurationRoot configuration)
		{
			_configuration = new ErechtheionConfiguration(configuration);
			Services.AddSingleton<IErechtheionConfiguration>(_configuration);
		}

		public void UseDbProviderFactory(DbProviderFactory dbProviderFactory)
		{
			Services.AddSingleton(dbProviderFactory);
		}
	}
}