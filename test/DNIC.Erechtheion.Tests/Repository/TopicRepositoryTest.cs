using System;
using System.Collections.Generic;
using System.Linq;
using DNIC.Erechtheion.Application.EnumTypes;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.Domain.ValueObjects;
using DNIC.Erechtheion.EntityFrameworkCore.Repositories;
using Xunit;

namespace DNIC.Erechtheion.Tests.Repository
{
	/// <summary>
	/// reference : https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory
	/// </summary>
	public class TopicRepositoryTest : TestBase
	{
		private ITopicRepository GetTopicReopsitory()
		{
			return new TopicRepository(GetDbContext("default"));
		}

		private IChannelRepository GetChannelRepository()
		{
			return new ChannelRepository(GetDbContext("channel"));
		}

		[Fact(DisplayName = "Create_Topic_Test")]
		public void TestCreateTopic()
		{
			// Arrange
			var context = GetDbContext("default");
			var contentChannels = new List<ContentChannels>()
			{
				new ContentChannels(1, "Hello World"),
				new ContentChannels(2,"Make .NET Great."),
			};
			var topicId = Guid.NewGuid();

			// Act
			var topic = new Topic(topicId, "Hello World", "hello-word", contentChannels, ContentType.Html, "I'm Iron man", ContentState.²Ý¸å);
			var entity = context.Topic.Add(topic);
			context.SaveChanges();
			topic = entity.Entity;

			var sameTopic = context.Topic.FirstOrDefault(x => x.AggregateId == topicId);
			var topicGotByChannel = context.Topic.FirstOrDefault(x => x.Channels.Any(o => o.ChannelId == 1));

			// Assert
			Assert.NotNull(topic);
			Assert.Equal(1, topic.Id);
			Assert.Equal(topic.Id, sameTopic.Id);
			Assert.Equal(topic.AggregateId, sameTopic.AggregateId);
			Assert.Equal(sameTopic.Channels, contentChannels);
			Assert.Equal(topicGotByChannel, topic);
		}
	}
}