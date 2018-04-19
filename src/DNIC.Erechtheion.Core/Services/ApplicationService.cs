using DNIC.Erechtheion.Core.AppServiceBase;
using DNIC.Erechtheion.Core.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.Services
{
	/// <summary>
	/// This class can be used as a base class for application services. 
	/// </summary>
	public abstract class ApplicationService : ErechtheionService, IApplicationService
	{
		public ApplicationService()
		{
		}
	}
}
