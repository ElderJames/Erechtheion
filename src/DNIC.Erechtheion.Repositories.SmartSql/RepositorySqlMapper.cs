using System;
using System.Collections.Generic;
using System.Text;
using SmartSql.Abstractions;

namespace DNIC.Erechtheion.Repositories.SmartSql
{
	public class RepositorySqlMapper
	{
		private ISmartSqlMapper smartSqlMapper { get; }

		public RepositorySqlMapper(ISmartSqlMapper smartSqlMapper)
		{
			this.smartSqlMapper = smartSqlMapper;
		}
	}
}