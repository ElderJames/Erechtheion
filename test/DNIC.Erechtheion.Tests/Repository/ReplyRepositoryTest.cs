using System;
using System.Linq;
using DNIC.Erechtheion.Application.EnumTypes;
using DNIC.Erechtheion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DNIC.Erechtheion.Tests.Repository
{
	public class ReplyRepositoryTest : TestBase
	{
		[Fact(DisplayName = "Test_Delete_Reply_Test")]
		public void Test_Delete_Reply_Test()
		{
			var context = GetDbContext("reply");

			var reply = new Reply(Guid.NewGuid(), Guid.NewGuid(), ReplyTargets.Topic, 10000, "dnic is greate!");

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
	}
}