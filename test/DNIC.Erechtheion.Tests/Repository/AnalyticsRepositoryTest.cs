using DNIC.Erechtheion.EntityFrameworkCore;
using DNIC.Erechtheion.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DNIC.Erechtheion.Tests.Repository
{
	public class AnalyticsRepositoryTestpublic : TestBase
	{
		private class TestAnalyticsRepository : AnalyticsRepository
		{
			public TestAnalyticsRepository(ErechtheionDbContext dbContext) : base(dbContext)
			{
			}

			public override DbConnection Connection => new SqlConnection("Server=server.silentartisan.com,40002;Database=DNIC.Erechtheion;User=sa;Password=1qazZAQ!;");
		}

		private AnalyticsRepository GetReopsitory(string name)
		{
			return new TestAnalyticsRepository(GetDbContext(name));
		}

		[Fact(DisplayName = "Analytics_Increase")]
		public async Task Analytics_Increase()
		{
			var key = "aaa";
			var repository = GetReopsitory("Analytics_Increase");
			await repository.IncreaseAsync(key);

			var result = await repository.GetByKeyAsync(key);
			Assert.Equal(1, result);
		}
	}
}
