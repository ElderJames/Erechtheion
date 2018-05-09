using System;

namespace DNIC.Erechtheion.Core.Configuration
{
	[Flags]
	public enum AuthenticationMode
	{
		Self = 1,
		External = 2,
		SelfAndExternal = Self | External
	}
}
