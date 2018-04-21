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
			if (!_contexts.ContainsKey(databaseName))
			{
				lock (_locker)
				{
					var options = new DbContextOptionsBuilder<ErechtheionDbContext>()
						.UseInMemoryDatabase(databaseName)
						.Options;

					var claimsPrincipal = new ClaimsPrincipal(new List<ClaimsIdentity>()
					{
						new ClaimsIdentity(new List<Claim>() {new Claim(ClaimTypes.NameIdentifier, "1")})
					});

					var mock = new Mock<IHttpContextAccessor>();
					mock.Setup(acr => acr.HttpContext.User).Returns(claimsPrincipal);

					var accessor = mock.Object;

					var context = new ErechtheionDbContext(options, accessor);
					_contexts.TryAdd(databaseName, context);
				}
			}

			return _contexts[databaseName];
		}
	}
}