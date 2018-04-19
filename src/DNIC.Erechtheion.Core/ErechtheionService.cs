using DNIC.Erechtheion.Core.Domain.Uow;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Erechtheion.Core
{
	public abstract class ErechtheionService
	{
		public IUnitOfWorkManager UnitOfWorkManager { get; private set; }

		/// <summary>
		/// Reference to the logger to write logs.
		/// </summary>
		public ILogger Logger { protected get; set; }

		public ErechtheionService(IUnitOfWorkManager unitOfWorkManager)
		{
			UnitOfWorkManager = unitOfWorkManager;
		}
	}
}
