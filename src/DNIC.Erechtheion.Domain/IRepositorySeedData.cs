using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Domain
{
	public interface IRepositorySeedData
	{
		void EnsureSeedData(IServiceProvider serviceProvider);
	}
}
