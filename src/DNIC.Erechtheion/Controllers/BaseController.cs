using DNIC.Erechtheion.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNIC.Erechtheion.Controllers
{
	public class BaseController : Controller
	{
		protected readonly IErechtheionConfiguration _erechtheionConfiguration;

		public BaseController(IErechtheionConfiguration erechtheionConfiguration)
		{
			_erechtheionConfiguration = erechtheionConfiguration;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			ViewData["AccountCenter"] = _erechtheionConfiguration.AccountCenter;
			base.OnActionExecuting(context);
		}
	}
}
