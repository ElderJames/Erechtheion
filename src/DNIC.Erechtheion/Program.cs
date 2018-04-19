using DNIC.Erechtheion.Core;
using DNIC.Erechtheion.Domain;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DNIC.Erechtheion
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = BuildWebHost(args);
			foreach (var initiator in host.Services.GetServices<ISeedDataInitiator>())
			{
				initiator.EnsureSeedData();
			}
			host.Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.Build();
	}
}