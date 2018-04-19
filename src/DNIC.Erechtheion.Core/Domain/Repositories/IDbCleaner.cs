using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.RepositoryBase
{
	/// <summary>
	/// 数据库清理者接口
	/// </summary>
	public interface IDbCleaner
	{
		/// <summary>
		/// 清理
		/// </summary>
		void Clean();
	}
}
