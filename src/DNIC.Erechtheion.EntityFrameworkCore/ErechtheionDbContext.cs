using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core.Domain;
using DNIC.Erechtheion.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DNIC.Erechtheion.EntityFrameworkCore
{
	public class ErechtheionDbContext : DbContext
	{
		public IHttpContextAccessor Accessor { get; private set; }

		public DbSet<Topic> Topic { get; set; }

		public DbSet<Channel> Channel { get; set; }

		public DbSet<Analytics> Analytics { get; set; }

		public ErechtheionDbContext(DbContextOptions<ErechtheionDbContext> options, IHttpContextAccessor accessor)
			: base(options)
		{
			Accessor = accessor;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Topic>().ToTable("Topic").HasMany(o => o.Channels);
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