using System;

namespace DNIC.Erechtheion.Core.Services.Dto
{
	/// <summary>
	/// A shortcut of <see cref="EntityDto{TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
	/// </summary>
	[Serializable]
	public class EntityDto : IEntityDto
	{
	}
}
