using DNIC.Erechtheion.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNIC.Erechtheion.Domain.Entities
{
	public class Channel : DisableAggregateRootEntity, ITree<Channel>
	{
		public bool IsRoot => this.ParentNode == null;

		public bool IsLeaf => !this.ChildNodes.Any();

		public virtual Channel ParentNode { get; }

		public virtual ICollection<Channel> ChildNodes { get; }

		public virtual string Name { get; private set; }

		public virtual string Description { get; private set; }

		public virtual string Icon { get; private set; }

		public virtual string BgColor { get; private set; }

		public virtual string Slug { get; private set; }

		public virtual int Order { get; private set; }

		public virtual string Link { get; private set; }

		public virtual string Class { get; private set; }

		public virtual string ImageClass { get; private set; }
	}
}
