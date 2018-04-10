using DNIC.Erechtheion.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNIC.Erechtheion.Controllers
{
	public class BaseController : Controller
	{
		protected readonly IErechtheionConfiguration _erechtheionConfiguration;
		protected readonly ILogger Logger;

		public BaseController(IErechtheionConfiguration erechtheionConfiguration)
		{
			_erechtheionConfiguration = erechtheionConfiguration;
			Logger = Log.ForContext(GetType());
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			base.OnActionExecuting(context);
		}
	}
}
