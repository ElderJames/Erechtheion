using System;
using System.ComponentModel.DataAnnotations;
using DNIC.Erechtheion.Core.Domain.ValueObjects;

namespace DNIC.Erechtheion.Domain.ValueObjects
{
	public class ContentChannels : ValueObject<ContentChannels>
	{
		private ContentChannels()
		{
		}

		public ContentChannels(long channelId, string channelName)
		{
			this.ChannelId = channelId;
			this.ChannelName = channelName;
		}

		public long Id { get; private set; }

		public long ChannelId { get; private set; }

		public string ChannelName { get; private set; }

		protected override bool EqualsCore(ContentChannels other)
		{
			return this.ChannelId == other.ChannelId;
		}

		protected override int GetHashCodeCore()
		{
			return ChannelId.GetHashCode();
		}
	}
}