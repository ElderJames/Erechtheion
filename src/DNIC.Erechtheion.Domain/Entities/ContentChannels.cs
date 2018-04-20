using DNIC.Erechtheion.Core.Domain.Entities;
using System;

namespace DNIC.Erechtheion.Domain.Entities
{
	public class ContentChannels : AuditedEntity
	{
		public Guid ContentId { get; private set; }

		public Guid ChannelId { get; private set; }
	}
}
