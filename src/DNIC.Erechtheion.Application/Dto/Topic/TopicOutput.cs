using System;

namespace DNIC.Erechtheion.Application.Dto
{
	public class TopicOutput
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public DateTime? LastModificationTime { get; set; }

		public long? LastModifierUserId { get; set; }

		public DateTime CreationTime { get; set; }

		public long? CreatorUserId { get; set; }
	}
}