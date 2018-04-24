using DNIC.Erechtheion.Core.Domain.Repositories;
using DNIC.Erechtheion.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using DNIC.Erechtheion.Domain.Entities;

namespace DNIC.Erechtheion.EntityFrameworkCore.Repositories
{
	public class AnalyticsRepository : IRepository, IAnalyticsReository
	{
		public readonly ErechtheionDbContext dbContext;

		public AnalyticsRepository(ErechtheionDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public virtual DbConnection Connection
		{
			get
			{
				var connection = dbContext.Database.GetDbConnection();

				if (connection.State != ConnectionState.Open)
				{
					connection.Open();
				}

				return connection;
			}
		}

		public async Task DecreaseAsync(string key)
		{
			await Connection.ExecuteAsync("update [Analytics] set [Value] = [Value] + 1;");
		}

		public async Task<int> GetByKeyAsync(string key)
		{
			return await Connection.QueryFirstAsync<int>("select [Key], [Value] from [Analytics] where [Key] = @Key;", new { Key = key });
		}

		public async Task<IEnumerable<Analytics>> GetByKeysAsync(IEnumerable<string> keys)
		{
			var keyParamenters = keys.Select(k => new { Key = k });
			return await Connection.QueryAsync<Analytics>("select [Key], [Value] from [Analytics] where [Key] = @Key;", keyParamenters);
		}

		public async Task IncreaseAsync(string key)
		{
			await Connection.ExecuteAsync("update [Analytics] set [Value] = [Value] - 1 where [Value] > 0;");
		}
	}
}
