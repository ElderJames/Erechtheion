using System;
using System.Collections.Generic;
using System.Text;
using DNIC.Erechtheion.Application.EnumTypes;

namespace DNIC.Erechtheion.Application.Dto.Reply
{
	public class ChangeReplyDto
	{
		public Guid ReplyId { get; set; }

		public long UserId { get; set; }

		public ContentType ContentType { get; set; }

		public string Content { get; set; }
	}
}