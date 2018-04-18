using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain
{
	[Serializable]
	public abstract class AggregateRootEntity : PlainEntity
	{
		public Guid AggregateId { get; set; }

		/// <summary>
		/// 构造器
		/// </summary>
		protected AggregateRootEntity()
		{
		}
	}

	[Serializable]
	public abstract class DisableAggregateRootEntity : AggregateRootEntity, IDisable
	{
		/// <summary>
		/// 构造器
		/// </summary>
		protected DisableAggregateRootEntity()
		{
		}

		public bool Enabled { get; private set; }

		public void Disable()
		{
			Enabled = false;
		}

		public void Enable()
		{
			Enabled = true;
		}
	}
}
