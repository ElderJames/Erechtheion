using DNIC.Erechtheion.Core.Domain;
using DNIC.Erechtheion.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Domain.Entities
{
	public class Analytics : Entity<int>
	{
		public virtual string Key { get; private set; }
		public virtual string Value { get; private set; }
	}
}
