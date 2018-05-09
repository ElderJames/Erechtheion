using System;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.EnumTypes;
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
		private string content = "hello world";

		[Fact(DisplayName = "Reply_Create_Test")]
		public void Reply_Create_Test()
		{
			var reply = new Reply(aggregateId, contentId, targetId, target, userId, content);

			Assert.Equal(aggregateId, reply.AggregateId);
			Assert.Equal(targetId, reply.TargetId);
			Assert.Equal(contentId, reply.ContentId);
			Assert.Equal(target, reply.Target);
			Assert.Equal(userId, reply.UserId);
			Assert.Equal(content, reply.Content);
		}

		[Fact(DisplayName = "Reply_Change_Test")]
		public void Reply_Change_Test()
		{
			var reply = new Reply(aggregateId, contentId, targetId, target, userId, content);

			reply.Change(".net is greate");

			Assert.Equal(aggregateId, reply.AggregateId);
			Assert.Equal(targetId, reply.TargetId);
			Assert.Equal(contentId, reply.ContentId);
			Assert.Equal(target, reply.Target);
			Assert.Equal(userId, reply.UserId);
			Assert.NotEqual(content, reply.Content);
			Assert.Equal(".net is greate", reply.Content);
		}
	}
}