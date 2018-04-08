using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core
{
	public class ErechtheionException : Exception
	{
		public ErechtheionException() { }

		public ErechtheionException(string msg) : base(msg) { }
	}
}
