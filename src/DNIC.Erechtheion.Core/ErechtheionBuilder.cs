using System;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.Core
{
	public class ErechtheionBuilder : IErechtheionBuilder
	{
		public ErechtheionBuilder(IServiceCollection services)
		{
			this.Services = services;
		}

		public IServiceCollection Services { get; }

		public void UseSmartSql(Func<object, object> p)
		{
		}
	}
}