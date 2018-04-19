using System;
using System.Collections.Generic;
using System.Text;
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
	}
}