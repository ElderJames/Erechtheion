using DNIC.Erechtheion.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DNIC.Erechtheion.Queries.Dapper
{
	public class BaseQueryService
	{
		private readonly DbProviderFactory _dbProviderFactory;
		private readonly IErechtheionConfiguration _configuration;

		protected BaseQueryService(DbProviderFactory dbProviderFactory,
			IErechtheionConfiguration configuration)
		{
			_dbProviderFactory = dbProviderFactory;
			_configuration = configuration;
		}

		public IDbConnection GetDbConnection()
		{
			var conn = _dbProviderFactory.CreateConnection();
			conn.ConnectionString = _configuration.ConnectionString;
			return conn;
		}
	}
}
