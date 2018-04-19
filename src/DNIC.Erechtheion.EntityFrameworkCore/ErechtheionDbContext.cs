using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core.Domain;
using DNIC.Erechtheion.Domain;
using DNIC.Erechtheion.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DNIC.Erechtheion.EntityFrameworkCore
{
	public class ErechtheionDbContext : DbContext
	{
		public IHttpContextAccessor Accessor { get; private set; }

		public DbSet<Topic> Topic { get; set; }

		public ErechtheionDbContext(DbContextOptions<ErechtheionDbContext> options, IHttpContextAccessor accessor)
			: base(options)
		{
			Accessor = accessor;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			//builder.Entity<ApplicationUserClaim>().HasOne(pt => pt.ApplicationUser).WithMany(t => t.Claims).HasForeignKey(pt => pt.UserId);
			//builder.Entity<ApplicationUserRole>().HasOne(pt => pt.ApplicationUser).WithMany(t => t.Roles).HasForeignKey(pt => pt.UserId);
			//builder.Entity<ApplicationUserLogin>().HasOne(pt => pt.ApplicationUser).WithMany(t => t.Logins).HasForeignKey(pt => pt.UserId);
			//builder.Entity<Node>().HasAlternateKey(c => c.NodeId).HasName("AlternateKey_NodeId");
			//builder.Entity<TaskLog>().HasAlternateKey(c => c.Identity).HasName("AlternateKey_Identity");
		}

		public override int SaveChanges()
		{
			ApplyConcepts();
			return base.SaveChanges();
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			ApplyConcepts();
			return await base.SaveChangesAsync(cancellationToken);
		}

		private void ApplyConcepts()
		{
			var value = Accessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			long.TryParse(value, out var userId);

			var entries = ChangeTracker.Entries();
			foreach (var entry in entries)
			{
				if (entry.Entity is IAudited e)
				{
					switch (entry.State)
					{
						case EntityState.Added:
							e.CreatorUserId = userId;
							e.CreationTime = DateTime.Now;
							break;

						case EntityState.Modified:
							e.LastModifierUserId = userId;
							e.LastModificationTime = DateTime.Now;
							break;
					}
				}
			}
		}
	}
}