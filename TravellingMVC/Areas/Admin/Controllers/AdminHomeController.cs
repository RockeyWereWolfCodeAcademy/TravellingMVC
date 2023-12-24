using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using TravellingMVC.Contexts;
using TravellingMVC.ViewModels.DestinationVM;

namespace TravellingMVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminHomeController : Controller
	{
		TravellingDbContext _context { get; }

        public AdminHomeController(TravellingDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult>  Index()
		{
			var vm = await _context.Destinations.Select(destination => new DestinationListVM
			{
				Id = destination.Id,
				Name = destination.Name,
				ImgUrl	= destination.ImgUrl,
				Price = destination.Price,
				PostalCode = destination.PostalCode,
				Rating	= destination.Rating,
			}).ToListAsync();
			return View(vm);
		}
		
    }
}
