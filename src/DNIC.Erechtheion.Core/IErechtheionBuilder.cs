using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DNIC.Erechtheion.Core
{
	public interface IErechtheionBuilder
	{
		IServiceCollection Services { get; }
	}
}