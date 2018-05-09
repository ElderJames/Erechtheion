using System;
using System.Collections.Generic;
using System.Text;
using SmartSql.Abstractions;

namespace DNIC.Erechtheion.Repositories.SmartSql
{
	public class RepositorySqlMapper
	{
		public ISmartSqlMapper SmartSqlMapper { get; }

		public RepositorySqlMapper(ISmartSqlMapper smartSqlMapper)
		{
			SmartSqlMapper = smartSqlMapper;
		}
	}
}