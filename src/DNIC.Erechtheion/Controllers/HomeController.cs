using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DNIC.Erechtheion.Models;
using DNIC.Erechtheion.Core.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace DNIC.Erechtheion.Controllers
{
	public class HomeController : BaseController
	{
		public HomeController(IErechtheionConfiguration erechtheionConfiguration) : base(erechtheionConfiguration)
		{
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[Authorize]
		public IActionResult Secure()
		{
			var user = User;
			ViewData["Message"] = "Secure page.";

			return View();
		}
	}
}