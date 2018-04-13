using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DNIC.Erechtheion.Core.Conditions;
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
		[Fact(DisplayName = "TopicRepository_Add_Test")]
		public async void TopicRepository_Add_Test()
		{
			// Arrange
			var topicRepository = GetReopsitory();
			var topic = new Topic("erechtheion");

			// Act
			var addedTopic = await topicRepository.Create(topic);

			// Assert
			Assert.Equal("erechtheion", addedTopic.Name);
			Assert.Equal(1, addedTopic.CreatorUserId);
			Assert.True(addedTopic.Id > 0);
		}

		[Fact(DisplayName = "TopicRepository_Update_Test")]
		public async void TopicRepository_Update_Test()
		{
			// Arrange
			var topicRepository = GetReopsitory();
			var topic = new Topic("erechtheion");

			// Act
			var addedTopic = await topicRepository.Create(topic);
			addedTopic.Change("erechtheion_updated");
			var updatedTopic = await topicRepository.Update(addedTopic);

			// Assert
			Assert.True(updatedTopic);
			Assert.Equal("erechtheion_updated", addedTopic.Name);
			Assert.Equal(1, addedTopic.CreatorUserId);
			Assert.True(topic.LastModificationTime != null);
		}

		[Fact(DisplayName = "TopicRepository_GetById_Test")]
		public async void TopicRepository_GetById_Test()
		{
			// Arrange
			var topicRepository = GetReopsitory();
			var topic = new Topic("erechtheion");
			var addedTopic = await topicRepository.Create(topic);

			// Act
			var gotTopic = await topicRepository.GetById(addedTopic.Id);

			// Assert
			Assert.True(addedTopic.Id > 0);
			Assert.NotNull(gotTopic);
			Assert.Equal(gotTopic.Id, addedTopic.Id);
			Assert.Equal("erechtheion", gotTopic.Name);
			Assert.Equal(1, addedTopic.CreatorUserId);
		}

		[Fact(DisplayName = "TopicRepository_GetAll_Test")]
		public async void TopicRepository_GetAll_Test()
		{
			// Arrange
			var context = GetContext("TopicRepository_GetAll_Test");
			var topicRepository = new TopicRepository(context);

			await context.Topic.AddRangeAsync(new Topic("topic1"), new Topic("topic2"), new Topic("topic3"), new Topic("topic4"), new Topic("topic5"));
			await context.SaveChangesAsync();

			// Act
			var list = await topicRepository.GetAll();

			// Assert
			//	Assert.Equal(5, list.Count());
			Assert.Contains(list, x => x.Name == "topic1");
		}

		[Fact(DisplayName = "TopicRepository_FindList_Test")]
		public async void TopicRepository_FindList_Test()
		{
			// Arrange
			var context = GetContext("TopicRepository_FindList_Test");
			var topicRepository = new TopicRepository(context);

			await context.Topic.AddRangeAsync(new Topic("topic1"), new Topic("topic2"), new Topic("topic3"), new Topic("topic4"), new Topic("topic5"));
			await context.SaveChangesAsync();

			// Act
			var list = await topicRepository.FindList(new TopicSearch()
			{
				Name = "topic1"
			});

			// Assert
			//	Assert.Single(list);
			Assert.True(list.ElementAt(0).Name == "topic1");
		}

		[Fact(DisplayName = "TopicRepository_Search_Test")]
		public async void TopicRepository_Search_Test()
		{
			// Arrange
			var context = GetContext("TopicRepository_FindList_Test");
			var topicRepository = new TopicRepository(context);

			await context.Topic.AddRangeAsync(new Topic("topic1"), new Topic("topic2"), new Topic("topic3"), new Topic("topic4"), new Topic("topic5"));
			await context.SaveChangesAsync();

			// Act
			var paged = await topicRepository.Search(new TopicSearch()
			{
				PageSize = 2
			});

			// Assert
			Assert.Equal(2, paged.Records.Count());
		}

		private ITopicRepository GetReopsitory()
		{
			return new TopicRepository(GetContext("default"));
		}

		private ErechtheionDbContext GetContext(string databaseName)
		{
			var options = new DbContextOptionsBuilder<ErechtheionDbContext>()
				.UseInMemoryDatabase("databaseName")
				.Options;

			var claimsPrincipal = new ClaimsPrincipal(new List<ClaimsIdentity>()
			{
				new ClaimsIdentity(new List<Claim>() {new Claim(ClaimTypes.NameIdentifier, "1")})
			});

			var mock = new Mock<IHttpContextAccessor>();
			mock.Setup(acr => acr.HttpContext.User).Returns(claimsPrincipal);

			var accessor = mock.Object;

			return new ErechtheionDbContext(options, accessor);
		}
	}
}