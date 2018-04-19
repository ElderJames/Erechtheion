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
	public class TopicRepositoryTest : TestBase
	{
		private ITopicRepository GetReopsitory()
		{
			return new TopicRepository(GetDbContext("default"));
		}

		private Topic CreateTopic()
		{
			return new Topic(1, "Hello World", "hello-word", ContentType.Html, "I'm Iron man", TopicState.²Ý¸å);
		}
	}
}