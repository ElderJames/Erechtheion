using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.EntityFrameworkCore
{
	public class ErechtheionIdentityDbContext : IdentityDbContext<ErechtheionUser>
	{
		public ErechtheionIdentityDbContext(DbContextOptions<ErechtheionIdentityDbContext> options)
			: base(options)
		{
		}
	}
}
