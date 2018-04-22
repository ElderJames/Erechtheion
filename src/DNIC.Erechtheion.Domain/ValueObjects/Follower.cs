using System;
using DNIC.Erechtheion.Application.EnumTypes;
using DNIC.Erechtheion.Core.Domain.ValueObjects;

namespace DNIC.Erechtheion.Domain.ValueObjects
{
	public class Follow : ValueObject<Follow>
	{
		public Follow(string targetId, FollowTargets target, DateTime followTime)
		{
			this.TargetId = targetId;
			this.Target = target;
			this.FollowTime = followTime;
		}

		public string TargetId { get; private set; }

		public FollowTargets Target { get; private set; }

		public DateTime FollowTime { get; private set; }

		protected override bool EqualsCore(Follow other)
		{
			return this.TargetId == other.TargetId && this.Target == other.Target;
		}

		protected override int GetHashCodeCore()
		{
			return this.TargetId.GetHashCode() ^ this.Target.GetHashCode();
		}
	}
}