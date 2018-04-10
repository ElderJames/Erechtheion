using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DNIC.Erechtheion.Domain;
using DNIC.Erechtheion.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace DNIC.Erechtheion
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = BuildWebHost(args);
			host.Services.GetRequiredService<IRepositorySeedData>()?.EnsureSeedData(host.Services);
			host.Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.Build();
	}
}
