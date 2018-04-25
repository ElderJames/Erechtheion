using Microsoft.Extensions.Options;
using System.Data;
using System.Data.Common;

namespace DNIC.Erechtheion.SmartSql
{
	public class SmartSqlOptions : IOptions<SmartSqlOptions>
	{
		public SmartSqlOptions Value => this;

		public string SqlMapperPath { get; set; }

		public DbProviderFactory DbProviderFactory { get; set; }

		public string ConnectionString { get; set; }

		public string LoggingName { get; set; }

		public string ParameterPrefix { get; set; } = "@";
	}
}