using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DNIC.Erechtheion.Core.Sql
{
	public interface ISqlMap
	{
		string this[string scope, string key] { get; }
		void Load(Stream stream);
	}
}
