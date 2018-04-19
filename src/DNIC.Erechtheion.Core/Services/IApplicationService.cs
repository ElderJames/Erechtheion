﻿using DNIC.Erechtheion.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.AppServiceBase
{
	/// <summary>
	/// This interface must be implemented by all application services to identify them by convention.
	/// </summary>
	public interface IApplicationService : ITransientDependency
	{

	}
}
