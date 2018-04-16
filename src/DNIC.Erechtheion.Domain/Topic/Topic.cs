using System;
using System.ComponentModel.DataAnnotations;

namespace DNIC.Erechtheion.Domain.Topic
{
	public class Topic : AuditedEntity<Guid>
	{
		private Topic() : base(Guid.Empty)
		{
		}

		public Topic(string name) : this()
		{
			if (string.IsNullOrEmpty(name))
				return;

			Name = name;
		}

		[Required]
		[StringLength(32)]
		public string Name { get; private set; }

		public void Change(string name)
		{
			if (string.IsNullOrEmpty(name))
				return;

			Name = name;
		}
	}
}