using System;
using System.Collections.Generic;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.EnumTypes;
using DNIC.Erechtheion.Domain.ValueObjects;
using Xunit;

namespace DNIC.Erechtheion.Tests.Domain
{
	public class TopicTest
	{
		[Fact(DisplayName = "Topic_Create_Test")]
		public void Topic_Create_Test()
		{
			// Arrange
			var title = "ABCDEFG";
			var slug = "abcdefg";
			var type = ContentType.MarkDown;
			var content = "This is Content.";
			var state = ContentState.已发布;

			// Act
			var subject = new Topic(Guid.NewGuid(), title, slug, new List<ContentChannels>(), type, content, state);

			// Assert
			Assert.Equal(title, subject.Title);
			Assert.Equal(type, subject.ContentType);
			Assert.Equal(content, subject.Content);
			Assert.Equal(state, subject.State);
		}

		[Fact(DisplayName = "Topic_Change_Test")]
		public void Topic_Change_Test()
		{
			// Arrange
			var title = "ABCDEFG";
			var slug = "abcdefg";
			var type = ContentType.MarkDown;
			var content = "This is Content.";
			var state = ContentState.已发布;
			var subject = new Topic(Guid.NewGuid(), "Hello World222", "hello-word222", new List<ContentChannels>(), ContentType.Html, "I'm Iron man", ContentState.草稿);

			// Act
			subject.Change(title, slug, type, content, state);

			// Assert
			Assert.Equal(title, subject.Title);
			Assert.Equal(type, subject.ContentType);
			Assert.Equal(content, subject.Content);
			Assert.Equal(state, subject.State);
		}
	}
}