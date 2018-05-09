using SmartSql.Abstractions;

namespace DNIC.Erechtheion.Queries.SmartSql
{
	public class QueriesSqlMapper
	{
		public ISmartSqlMapper SmartSqlMapper { get; }

		public QueriesSqlMapper(ISmartSqlMapper sqlMapper)
		{
			SmartSqlMapper = sqlMapper;
		}
	}
}