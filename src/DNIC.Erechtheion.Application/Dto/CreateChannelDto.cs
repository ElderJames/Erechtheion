using DNIC.Erechtheion.Core.DtoBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Application.Dto
{
	public class CreateChannelDto : BaseDto
	{
		public virtual string Name { get; private set; }

		public virtual long ParentId { get; set; }

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
