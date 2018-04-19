using DNIC.Erechtheion.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNIC.Erechtheion.Domain.Entities
{
	public class Analytics : Entity<int>
	{
		public virtual string Key { get; }
		public virtual dynamic Value { get; }
	}
}
