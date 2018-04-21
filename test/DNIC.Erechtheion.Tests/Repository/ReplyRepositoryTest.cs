using System;
using System.Linq;
using DNIC.Erechtheion.Application.EnumTypes;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DNIC.Erechtheion.Tests.Repository
{
	public class ReplyRepositoryTest : TestBase
	{
		[Fact(DisplayName = "Reply_Delete_With_Context_Test")]
		public void Reply_Delete_With_Context_Test()
		{
			var context = GetDbContext("Reply_Delete_With_Context_Test");

			var reply = new Reply(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), ReplyTargets.Topic, 10000, "dnic is greate!");

			context.Add(reply);
			context.SaveChanges();

			context.Replies.Remove(reply);
			context.SaveChanges();

			var sameReplies = context.Replies;
			var deletedReply = context.Replies.IgnoreQueryFilters().FirstOrDefault(x => EF.Property<bool>(x, "IsDeleted"));

			Assert.Empty(sameReplies);
			Assert.NotNull(deletedReply);
			Assert.Equal(reply, deletedReply);
		}

		[Fact(DisplayName = "Reply_Create_Test")]
		public void Reply_Create_Test()
		{
			var repository = GetReplyRepository("Reply_Create_Test");
			var aggregateId = Guid.NewGuid();
			var reply = new Reply(aggregateId, Guid.NewGuid(), Guid.NewGuid(), ReplyTargets.Topic, 10000, "dnic is greate!");

			var updateRows = repository.Create(reply);

			Assert.True(0 < updateRows);
		}

		[Fact(DisplayName = "Reply_Get_Test")]
		public void Reply_Get_Test()
		{
			var repository = GetReplyRepository("Reply_Get_Test");
			var aggregateId = Guid.NewGuid();
			var reply = new Reply(aggregateId, Guid.NewGuid(), Guid.NewGuid(), ReplyTargets.Topic, 10000, "dnic is greate!");

			var updateRows = repository.Create(reply);
			var createdReply = repository.Get(aggregateId);

			Assert.True(0 < updateRows);
			Assert.NotNull(createdReply);
			Assert.Equal(reply, createdReply);
		}

		[Fact(DisplayName = "Reply_Change_Test")]
		public void Reply_Change_Test()
		{
			var repository = GetReplyRepository("Reply_Change_Test");
			var aggregateId = Guid.NewGuid();
			var reply = new Reply(aggregateId, Guid.NewGuid(), Guid.NewGuid(), ReplyTargets.Topic, 10000, "dnic is greate!");

			repository.Create(reply);
			var createdReply = repository.Get(aggregateId);

			createdReply.Change("hhhhhhh");
			var updateRows = repository.Update(createdReply);

			var updateReply = repository.Get(aggregateId);

			Assert.True(0 < updateRows);
			Assert.Equal("hhhhhhh", updateReply.Content);
		}

		[Fact(DisplayName = "Reply_Delete_Test")]
		public void Reply_Delete_Test()
		{
			var repository = GetReplyRepository("Reply_Delete_Test");
			var aggregateId = Guid.NewGuid();
			var reply = new Reply(aggregateId, Guid.NewGuid(), Guid.NewGuid(), ReplyTargets.Topic, 10000, "dnic is greate!");

			repository.Create(reply);
			var createdReply = repository.Get(aggregateId);
			var updateRows = repository.Delete(createdReply);
			var deleteReply = repository.Get(aggregateId);

			Assert.True(0 < updateRows);
			Assert.Null(deleteReply);
		}

		private IReplyRepository GetReplyRepository(string name)
		{
			return new ReplyRepository(GetDbContext(name));
		}
	}
}