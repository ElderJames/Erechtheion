using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.EventBase
{
	/// <summary>
	/// 领域事件源基接口
	/// </summary>
	public interface IEvent
	{
		/// <summary>
		/// 标识
		/// </summary>
		Guid Id { get; }

		/// <summary>
		/// 是否已处理
		/// </summary>
		bool Handled { get; }

		/// <summary>
		/// 会话Id
		/// </summary>
		Guid SessionId { get; }

		/// <summary>
		/// Creation time of this entity.
		/// </summary>
		DateTime CreationTime { get; set; }
	}
}
