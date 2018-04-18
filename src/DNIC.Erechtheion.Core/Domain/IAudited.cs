using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Domain
{
	/// <summary>
	/// This interface is implemented by entities which must be audited.
	/// Related properties automatically set when saving/updating <see cref="Entity"/> objects.
	/// </summary>
	public interface IAudited : ICreationAudited, IModificationAudited
	{
	}
}
