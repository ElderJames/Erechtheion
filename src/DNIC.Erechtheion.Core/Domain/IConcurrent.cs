using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain
{
	/// <summary>
	/// 可并发接口
	/// </summary>
	public interface IConcurrent
	{
		/// <summary>
		/// 行版本
		/// </summary>
		byte[] RowVersion { get; }
	}
}
