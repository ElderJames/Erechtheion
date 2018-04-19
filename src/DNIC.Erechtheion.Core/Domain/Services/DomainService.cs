using DNIC.Erechtheion.Core.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core.DomainServiceBase
{
	/// <summary>
	/// This class can be used as a base class for domain services. 
	/// </summary>
	public abstract class DomainService : ErechtheionService, IDomainService
	{
		public DomainService()
		{
		}
	}
}
