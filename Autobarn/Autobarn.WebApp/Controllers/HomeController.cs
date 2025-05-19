using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Autobarn.WebApp.Models;

namespace Autobarn.WebApp.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller {

	public IActionResult Index() {
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error() {
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
