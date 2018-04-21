using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using DNIC.Erechtheion.Core.Database;
using DNIC.Erechtheion.Core.Domain;
using DNIC.Erechtheion.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DNIC.Erechtheion.EntityFrameworkCore
{
	public class ErechtheionDbContext : DbContext
	{
		public IHttpContextAccessor Accessor { get; private set; }

		public DbSet<Topic> Topics { get; set; }

		public DbSet<Channel> Channels { get; set; }

		public DbSet<Reply> Replies { get; set; }

		public ErechtheionDbContext(DbContextOptions<ErechtheionDbContext> options, IHttpContextAccessor accessor)
			: base(options)
		{
			Accessor = accessor;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Topic>().HasMany(o => o.Channels);

			foreach (var entity in modelBuilder.Model.GetEntityTypes())
			{
				if (typeof(ISoftDeletable).IsAssignableFrom(entity.ClrType))
				{
					entity.AddProperty(_isDeletedProperty, typeof(bool));

					modelBuilder
						.Entity(entity.ClrType)
						.HasQueryFilter(GetIsDeletedRestriction(entity.ClrType))
						.HasIndex(_isDeletedProperty).HasName($"IDX_{_isDeletedProperty}");
				}
			}

			base.OnModelCreating(modelBuilder);
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
					var deletable = entry.Entity is ISoftDeletable;
					switch (entry.State)
					{
						case EntityState.Added:
							e.CreatorUserId = userId;
							e.CreationTime = DateTime.Now;
							if (deletable) entry.CurrentValues[_isDeletedProperty] = false;
							break;

						case EntityState.Modified:
							e.LastModifierUserId = userId;
							e.LastModificationTime = DateTime.Now;
							if (deletable) entry.CurrentValues[_isDeletedProperty] = false;
							break;

						case EntityState.Deleted:
							e.LastModifierUserId = userId;
							e.LastModificationTime = DateTime.Now;
							entry.State = EntityState.Modified;
							if (deletable) entry.CurrentValues[_isDeletedProperty] = true;
							break;
					}
				}
			}
		}

		#region solf delete

		private const string _isDeletedProperty = "IsDeleted";
		private static readonly MethodInfo _propertyMethod = typeof(EF).GetMethod(nameof(EF.Property), BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeof(bool));

		/// <summary>
		/// 创建lambda条件表达式
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private static LambdaExpression GetIsDeletedRestriction(Type type)
		{
			var parm = Expression.Parameter(type, "it");
			var prop = Expression.Call(_propertyMethod, parm, Expression.Constant(_isDeletedProperty));
			var condition = Expression.MakeBinary(ExpressionType.Equal, prop, Expression.Constant(false));
			return Expression.Lambda(condition, parm);
		}

		#endregion solf delete
	}
}