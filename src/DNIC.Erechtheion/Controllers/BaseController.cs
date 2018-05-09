using DNIC.Erechtheion.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace DNIC.Erechtheion.Controllers
{
	public class BaseController : Controller
	{
		protected readonly IErechtheionConfiguration _erechtheionConfiguration;
		protected readonly Serilog.ILogger Logger;

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
