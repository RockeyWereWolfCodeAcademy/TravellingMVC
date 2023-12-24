using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TravellingMVC.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}