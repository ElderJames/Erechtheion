﻿namespace DNIC.Erechtheion.Core.Domain.Repositories
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
