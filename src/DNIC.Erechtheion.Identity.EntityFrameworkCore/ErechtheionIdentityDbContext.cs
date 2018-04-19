using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DNIC.Erechtheion.Identity.EntityFrameworkCore
{
	public class ErechtheionIdentityDbContext : IdentityDbContext<ErechtheionUser>
	{
		public ErechtheionIdentityDbContext(DbContextOptions<ErechtheionIdentityDbContext> options)
			: base(options)
		{
		}
	}
}