using System;
using System.ComponentModel.DataAnnotations;

namespace DNIC.Erechtheion.Domain
{
	public interface IEntity
	{
	}

	/// <summary>
	/// 泛型实体基类
	/// </summary>
	/// <typeparam name="TPrimaryKey">主键类型</typeparam>
	public abstract class Entity<TAggregateId> : IEntity where TAggregateId : IEquatable<TAggregateId>
	{
		protected Entity(TAggregateId aggregateId)
		{
			AggregateId = aggregateId;
		}

		/// <summary>
		/// 主键
		/// </summary>
		[Key]
		public virtual int Id { get; set; }

		public virtual TAggregateId AggregateId { get; private set; }
	}

	/// <summary>
	/// 定义默认主键类型为Guid的实体基类
	/// </summary>
	public abstract class Entity : Entity<Guid>
	{
		protected Entity() : base(Guid.NewGuid())
		{
		}
	}
}