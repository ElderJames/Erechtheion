using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain
{
	public interface ICreationAudited
	{
		/// <summary>
		/// Id of the creator user of this entity.
		/// </summary>
		long? CreatorUserId { get; set; }

		/// <summary>
		/// Creation time of this entity.
		/// </summary>
		DateTime? CreationTime { get; set; }
	}
}
