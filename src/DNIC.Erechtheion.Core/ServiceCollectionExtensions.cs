using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core
{
	public static class ServiceCollectionExtensions
	{
		public static IErechtheionBuilder AddErechtheion(this IServiceCollection services, Action<IErechtheionBuilder> config)
		{
			IErechtheionBuilder builder = new ErechtheionBuilder(services);
			config(builder);
			return builder;
		}
	}
}
