using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain
{
	public interface IModificationAudited
	{
		/// <summary>
		/// Last modifier user for this entity.
		/// </summary>
		long? LastModifierUserId { get; set; }

		/// <summary>
		/// The last modified time for this entity.
		/// </summary>
		DateTime? LastModificationTime { get; set; }
	}
}
