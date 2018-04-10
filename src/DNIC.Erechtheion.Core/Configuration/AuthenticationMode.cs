using System;
using System.Collections.Generic;
using System.Text;

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
