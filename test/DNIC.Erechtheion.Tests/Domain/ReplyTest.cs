using System;
using DNIC.Erechtheion.Application.EnumTypes;
using DNIC.Erechtheion.Domain.Entities;
using Xunit;

namespace DNIC.Erechtheion.Tests.Domain
{
	public class ReplyTest
	{
		private Guid aggregateId = Guid.NewGuid();
		private Guid targetId = Guid.NewGuid();
		private Guid contentId = Guid.NewGuid();
		private ReplyTargets target = ReplyTargets.Topic;
		private long userId = 233333;
		private ContentType contentType = ContentType.MarkDown;
		private string content = "hello world";

		[Fact(DisplayName = "Reply_Create_Test")]
		public void Reply_Create_Test()
		{
			var reply = new Reply(aggregateId, contentId, targetId, target, userId, contentType, content);

			Assert.Equal(aggregateId, reply.AggregateId);
			Assert.Equal(targetId, reply.TargetId);
			Assert.Equal(contentId, reply.ContentId);
			Assert.Equal(target, reply.Target);
			Assert.Equal(userId, reply.UserId);
			Assert.Equal(contentType, reply.ContentType);
			Assert.Equal(content, reply.Content);
		}

		[Fact(DisplayName = "Reply_Change_Test")]
		public void Reply_Change_Test()
		{
			var reply = new Reply(aggregateId, contentId, targetId, target, userId, contentType, content);

			reply.ChangeContent(ContentType.Html, ".net is greate");

			Assert.Equal(aggregateId, reply.AggregateId);
			Assert.Equal(targetId, reply.TargetId);
			Assert.Equal(contentId, reply.ContentId);
			Assert.Equal(target, reply.Target);
			Assert.Equal(userId, reply.UserId);
			Assert.NotEqual(content, reply.Content);
			Assert.Equal(ContentType.Html, reply.ContentType);
			Assert.Equal(".net is greate", reply.Content);
		}

		[Fact(DisplayName = "Reply_Close_Test")]
		public void Reply_Close_Test()
		{
			var reply = new Reply(aggregateId, contentId, targetId, target, userId, contentType, content);

			reply.Close();

			Assert.True(reply.Closed);
		}
	}
}