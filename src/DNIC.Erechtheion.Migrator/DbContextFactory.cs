using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DNIC.Erechtheion.Migrator
{
	public class DbContextFactory : IDesignTimeDbContextFactory<ErechtheionDbContext>
	{
		private readonly string _connectionString;

		public DbContextFactory()
		{
			_connectionString = GetConnectionString();
		}

		public DbContextFactory(string connectionString)
		{
			_connectionString = connectionString;
		}

		public ErechtheionDbContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<ErechtheionDbContext>();
			builder.UseSqlServer(_connectionString);
			return new ErechtheionDbContext(builder.Options);
		}

		private string GetConnectionString()
		{
			var builder = new ConfigurationBuilder();
			builder.AddJsonFile("appsettings.json", optional: false);

			var configuration = builder.Build();

			return configuration.GetConnectionString("DefaultConnection");
		}
	}
}
