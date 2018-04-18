using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain
{
	/// <summary>
	/// 可停用接口
	/// </summary>
	public interface IDisable
	{
		#region # 属性

		#region 是否启用 —— bool Enabled
		/// <summary>
		/// 是否启用
		/// </summary>
		bool Enabled { get; }
		#endregion

		#endregion

		#region # 方法

		#region 启用 —— void Enable()
		/// <summary>
		/// 启用
		/// </summary>
		void Enable();
		#endregion

		#region 停用 —— void Disable()
		/// <summary>
		/// 停用
		/// </summary>
		void Disable();
		#endregion

		#endregion
	}
}
