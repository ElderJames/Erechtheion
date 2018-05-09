using System;

namespace DNIC.Erechtheion.Core.Domain.Entities
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
