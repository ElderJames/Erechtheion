using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Configuration
{
	public interface IErechtheionConfiguration
	{
		string AccountCenter { get; }
		string ConnectionString { get; }
		IConfiguration Configuration { get; }
	}
}
