using DNIC.Erechtheion.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Claims;

namespace DNIC.Erechtheion.Tests
{
	public abstract class TestBase
	{
		private readonly ConcurrentDictionary<string, ErechtheionDbContext> _contexts = new ConcurrentDictionary<string, ErechtheionDbContext>();
		private static readonly object _locker = new object();

		protected ErechtheionDbContext GetDbContext(string databaseName)
		{
			return _contexts.GetOrAdd(databaseName, (name) =>
			{
				var options = new DbContextOptionsBuilder<ErechtheionDbContext>()
					.UseInMemoryDatabase(name)
					.Options;

				var claimsPrincipal = new ClaimsPrincipal(new List<ClaimsIdentity>()
				{
					new ClaimsIdentity(new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, "1") })
				});

				var mock = new Mock<IHttpContextAccessor>();
				mock.Setup(acr => acr.HttpContext.User).Returns(claimsPrincipal);

				var accessor = mock.Object;

				return new ErechtheionDbContext(options, accessor);
			});
		}
	}
}