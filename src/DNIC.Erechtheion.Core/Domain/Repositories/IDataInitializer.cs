using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.RepositoryBase
{
	/// <summary>
	/// 数据初始化器接口
	/// </summary>
	public interface IDataInitializer
	{
		/// <summary>
		/// 初始化基础数据
		/// </summary>
		void Initialize();
	}
}
