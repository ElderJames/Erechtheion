using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain
{
	/// <summary>
	/// Used to standardize soft deleting entities.
	/// Soft-delete entities are not actually deleted,
	/// marked as IsDeleted = true in the database,
	/// but can not be retrieved to the application.
	/// </summary>
	public interface ISoftDelete
	{
		/// <summary>
		/// Used to mark an Entity as 'Deleted'. 
		/// </summary>
		bool Deleted { get; }

		/// <summary>
		/// Deletion time of this entity.
		/// </summary>
		DateTime? DeletionTime { get; }

		void Delete();
	}
}
