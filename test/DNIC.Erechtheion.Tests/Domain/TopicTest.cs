using System;
using System.Linq;
using DNIC.Erechtheion.Core.EnumTypes;
using DNIC.Erechtheion.Domain.Entities;
using Xunit;

namespace DNIC.Erechtheion.Tests.Domain
{
	public class TopicTest
	{
		[Fact(DisplayName = "Topic_Create_Test")]
		public void Topic_Create_Test()
		{
			// Arrange
			var channelId = 1;
			var title = "ABCDEFG";
			var slug = "abcdefg";
			var type = ContentType.MarkDown;
			var content = "This is Content.";
			var state = TopicState.已发布;

			// Act
			var subject = new Topic(channelId, title, slug, type, content, state);

			// Assert
			Assert.Equal(channelId, subject.ChannelId);
			Assert.Equal(title, subject.Title);
			Assert.Equal(type, subject.ContentType);
			Assert.Equal(content, subject.Content);
			Assert.Equal(state, subject.State);
		}

		[Fact(DisplayName = "Topic_Change_Test")]
		public void Topic_Change_Test()
		{
			// Arrange
			var channelId = 1;
			var title = "ABCDEFG";
			var slug = "abcdefg";
			var type = ContentType.MarkDown;
			var content = "This is Content.";
			var state = TopicState.已发布;
			var subject = new Topic(channelId, "Hello World222", "hello-word222", ContentType.Html, "I'm Iron man", TopicState.草稿);

			// Act
			subject.Change(1, title, slug, type, content, state);

			// Assert
			Assert.Equal(channelId, subject.ChannelId);
			Assert.Equal(title, subject.Title);
			Assert.Equal(type, subject.ContentType);
			Assert.Equal(content, subject.Content);
			Assert.Equal(state, subject.State);
		}
	}
}