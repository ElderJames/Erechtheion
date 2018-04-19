using System;
using System.Collections.Generic;
using System.Security.Claims;
using DNIC.Erechtheion.Core.EnumTypes;
using DNIC.Erechtheion.Domain.Entities;
using DNIC.Erechtheion.Domain.Repositories;
using DNIC.Erechtheion.EntityFrameworkCore;
using DNIC.Erechtheion.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DNIC.Erechtheion.Tests.Repository
{
	/// <summary>
	/// reference : https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory
	/// </summary>
	public class TopicRepositoryTest
	{
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

		private Topic CreateTopic()
		{
			return new Topic(1, "Hello World", "hello-word", ContentType.Html, "I'm Iron man", TopicState.²Ý¸å);
		}
	}
}