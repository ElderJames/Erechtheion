using DNIC.Erechtheion.Core.Database;
using DNIC.Erechtheion.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DNIC.Erechtheion.Migrator
{
	/// <summary>
	/// 此类只是用来做建库、建表、迁移工作。并不会在实际业务中使用 EF
	/// </summary>
	public class ErechtheionDbContext : IdentityDbContext<ErechtheionUser>
	{
		public DbSet<Topic> Topics { get; set; }

		public DbSet<Channel> Channels { get; set; }

		public DbSet<Reply> Replies { get; set; }

		public DbSet<Analytics> Analytics { get; set; }

		public ErechtheionDbContext(DbContextOptions<ErechtheionDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			foreach (var entity in builder.Model.GetEntityTypes())
			{
				if (typeof(ISoftDeletable).IsAssignableFrom(entity.ClrType))
				{
					entity.AddProperty(IsDeletedProperty, typeof(bool));

					builder.Entity(entity.ClrType)
						.HasQueryFilter(GetIsDeletedRestriction(entity.ClrType))
						.HasIndex(IsDeletedProperty).HasName($"IDX_{IsDeletedProperty}");
				}
			}
			builder.Entity<Topic>().ToTable("Topic").HasMany(o => o.Channels);
		}

	
		#region solf delete

		private const string IsDeletedProperty = "IsDeleted";
		private static readonly MethodInfo PropertyMethod = typeof(EF).GetMethod(nameof(EF.Property), BindingFlags.Static | BindingFlags.Public).MakeGenericMethod(typeof(bool));

		/// <summary>
		/// 创建lambda条件表达式
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		private static LambdaExpression GetIsDeletedRestriction(Type type)
		{
			var parm = Expression.Parameter(type, "it");
			var prop = Expression.Call(PropertyMethod, parm, Expression.Constant(IsDeletedProperty));
			var condition = Expression.MakeBinary(ExpressionType.Equal, prop, Expression.Constant(false));
			return Expression.Lambda(condition, parm);
		}

		#endregion solf delete
	}
}
