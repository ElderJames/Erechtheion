using System;
using System.Linq;
using DNIC.Erechtheion.Core.EnumTypes;
using DNIC.Erechtheion.Domain.Subject;
using Xunit;

namespace DNIC.Erechtheion.Tests.Domain
{
	public class SubjectTest
	{
		[Fact(DisplayName = "Subject_Create_Test")]
		public void Subject_Create_Test()
		{
			// Arrange
			var aggregateId = Guid.NewGuid();
			var sectionId = Guid.NewGuid();
			var authorId = 123456789L;
			var title = "ABCDEFG";
			var type = ContentTypes.MarkDown;
			var content = "This is Content.";
			var state = SubjectStates.已发布;

			// Act
			var subject = new Subject(aggregateId, authorId, sectionId, title, type, content, state);

			// Assert
			Assert.Equal(aggregateId, subject.AggregateId);
			Assert.Equal(sectionId, subject.SectionId);
			Assert.Equal(authorId, subject.AuthorId);
			Assert.Equal(title, subject.Title);
			Assert.Equal(type, subject.ContentType);
			Assert.Equal(content, subject.Content);
			Assert.Equal(state, subject.State);
		}

		[Fact(DisplayName = "Subject_Change_Test")]
		public void Subject_Change_Test()
		{
			// Arrange
			var aggregateId = Guid.NewGuid();
			var sectionId = Guid.NewGuid();
			var authorId = 123456789L;
			var title = "ABCDEFG";
			var type = ContentTypes.MarkDown;
			var content = "This is Content.";
			var state = SubjectStates.已发布;
			var subject = new Subject(aggregateId, authorId, Guid.NewGuid(), "Hello World", ContentTypes.Html, "I'm Iron man", SubjectStates.草稿);

			// Act
			subject.Change(sectionId, title, type, content, state);

			// Assert
			Assert.Equal(aggregateId, subject.AggregateId);
			Assert.Equal(sectionId, subject.SectionId);
			Assert.Equal(authorId, subject.AuthorId);
			Assert.Equal(title, subject.Title);
			Assert.Equal(type, subject.ContentType);
			Assert.Equal(content, subject.Content);
			Assert.Equal(state, subject.State);
		}

		[Fact]
		public void Subject_Add_And_Subtract_Comments_Test()
		{
			// Arrange
			var subject = new Subject(Guid.NewGuid(), 12345678L, Guid.NewGuid(), "Hello World", ContentTypes.Html, "I'm Iron man", SubjectStates.草稿);

			// Act
			Enumerable.Range(1, 100).ToList().ForEach(x => subject.AddComments());

			// Assert
			Assert.Equal(100, subject.Comments);

			// Act
			Enumerable.Range(1, 50).ToList().ForEach(x => subject.SubtractComments());

			// Assert
			Assert.Equal(50, subject.Comments);

			// Act
			Enumerable.Range(1, 51).ToList().ForEach(x => subject.SubtractComments());

			// Assert
			Assert.Equal(0, subject.Comments);
		}

		[Fact]
		public void Subject_AddHits_Test()
		{
			// Arrange
			var subject = new Subject(Guid.NewGuid(), 12345678L, Guid.NewGuid(), "Hello World", ContentTypes.Html, "I'm Iron man", SubjectStates.草稿);

			// Act
			Enumerable.Range(1, 100).ToList().ForEach(x => subject.AddHits());

			// Assert
			Assert.Equal(100, subject.Hits);
		}

		[Fact]
		public void Subject_Add_And_Subtract_Likes_Test()
		{
			// Arrange
			var subject = new Subject(Guid.NewGuid(), 12345678L, Guid.NewGuid(), "Hello World", ContentTypes.Html, "I'm Iron man", SubjectStates.草稿);

			// Act
			Enumerable.Range(1, 100).ToList().ForEach(x => subject.AddLikes());

			// Assert
			Assert.Equal(100, subject.Likes);

			// Act
			Enumerable.Range(1, 50).ToList().ForEach(x => subject.SubtractLikes());

			// Assert
			Assert.Equal(50, subject.Likes);

			// Act
			Enumerable.Range(1, 51).ToList().ForEach(x => subject.SubtractLikes());

			// Assert
			Assert.Equal(0, subject.Likes);
		}
	}
}