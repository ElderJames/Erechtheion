using System.Collections.Generic;
using DNIC.Erechtheion.Application.EnumTypes;
using DNIC.Erechtheion.Core.Domain.Entities;
using DNIC.Erechtheion.Domain.ValueObjects;

namespace DNIC.Erechtheion.Domain.Entities
{
	public class UserInfo : AuditedAggregateRoot<int, long>
	{
		public UserInfo() : base(0)
		{
		}

		public UserInfo(long aggregateId) : base(aggregateId)
		{
		}

		/// <summary>
		/// 被关注数
		/// </summary>
		public int Followers { get; private set; }

		/// <summary>
		/// 关注数
		/// </summary>
		public int Following { get; private set; }

		/// <summary>
		/// 关注信息
		/// </summary>
		public ICollection<Follow> Follows { get; private set; }

		/// <summary>
		/// 添加一个关注者
		/// </summary>
		/// <param name="followTarget"></param>
		public void Follow(Follow followTarget)
		{
			this.Follows.Add(followTarget);
			if (followTarget.Target == FollowTargets.Users)
				Following++;
		}
	}
}