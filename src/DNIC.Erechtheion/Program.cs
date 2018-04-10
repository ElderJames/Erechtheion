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
			host.Services.GetRequiredService<IRepositorySeedData>()?.EnsureSeedData();
			host.Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.Build();
	}
}