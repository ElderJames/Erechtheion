using System;
using System.Data.Common;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.Core
{
	public interface IErechtheionBuilder
	{
		IErechtheionConfiguration Configuratoin { get; }
		IServiceCollection Services { get; }
		void UseDbProviderFactory(DbProviderFactory dbProviderFactory);
		void UseConfiguration(IConfigurationRoot configuration);
	}
}