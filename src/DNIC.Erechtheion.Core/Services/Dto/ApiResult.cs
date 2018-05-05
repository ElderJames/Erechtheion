using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Services.Dto
{
	public class ApiResult<TResult>
	{
		public TResult Result { get; set; }

		public ResultStatus Status { get; set; }

		public string Message { get; set; }
	}
}