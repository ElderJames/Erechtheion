using System;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion.Core
{
	public interface IErechtheionBuilder
	{
		IServiceCollection Services { get; }

		void UseSmartSql(Func<object, object> p);
	}
}