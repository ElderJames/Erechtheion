using System;
using System.Collections.Generic;
using System.Text;
using SmartSql.Abstractions;

namespace DNIC.Erechtheion.QuerySerivces.SmartSql
{
	public class QueryServiceSqlMapper
	{
		public ISmartSqlMapper sqlMapper { get; }

		public QueryServiceSqlMapper(ISmartSqlMapper sqlMapper)
		{
			this.sqlMapper = sqlMapper;
		}
	}
}