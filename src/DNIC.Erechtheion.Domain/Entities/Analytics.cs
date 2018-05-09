using DNIC.Erechtheion.Core.Domain.Entities;

namespace DNIC.Erechtheion.Domain.Entities
{
	public class Analytics : Entity<int>
	{
		public virtual string Key { get; private set; }
		public virtual string Value { get; private set; }
	}
}
