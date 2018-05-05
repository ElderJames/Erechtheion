using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Application.Dto.Reply
{
	public class CloseReplyDto
	{
		public Guid ReplyId { get; set; }

		public long UserId { get; set; }
	}
}