using System.Collections.Generic;
using System.Security.Claims;
using DNIC.Erechtheion.Domain.Topic;
using DNIC.Erechtheion.EntityFrameworkCore;
using DNIC.Erechtheion.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace DNIC.Erechtheion.Tests.Repository
{
	/// <summary>
	/// reference : https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory
	/// </summary>
	public class TopicRepositoryTest
	{
		[Fact(DisplayName = "Add_Topic_To_Database_Test")]
		public void Add_Topic_To_Database_Test()
		{
			// Arrange
			var options = new DbContextOptionsBuilder<ErechtheionDbContext>()
				.UseInMemoryDatabase("Add_Topic_To_Database")
				.Options;

			var claimsPrincipal = new ClaimsPrincipal(new List<ClaimsIdentity>()
			{
				new ClaimsIdentity(new List<Claim>() {new Claim(ClaimTypes.NameIdentifier, "1")})
			});

			var mock = new Mock<IHttpContextAccessor>();
			mock.Setup(acr => acr.HttpContext.User).Returns(claimsPrincipal);
			var accessor = mock.Object;

			var topic = new Topic("erechtheion");

			var context = new ErechtheionDbContext(options, accessor);

			ITopicRepository topicRepository = new TopicRepository(context);

			// Act
			var addedTopic = topicRepository.Create(topic).Result;

			// Assert
			Assert.Equal(addedTopic.Name, topic.Name);
			Assert.Equal(1, addedTopic.CreatorUserId);
			Assert.True(addedTopic.Id > 0);
		}
	}
}