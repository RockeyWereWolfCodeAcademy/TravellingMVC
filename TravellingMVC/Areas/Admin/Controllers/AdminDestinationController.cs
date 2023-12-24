using Microsoft.AspNetCore.Mvc;
using TravellingMVC.Areas.Admin.ViewModels.AdminDestinationVM;
using TravellingMVC.Contexts;
using TravellingMVC.Helpers;
using TravellingMVC.Models;

namespace TravellingMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDestinationController : Controller
    {
        TravellingDbContext _context { get; }

        public AdminDestinationController(TravellingDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public async Task <IActionResult> Create(AdminDestinationCreateVM destinationVM)
		{
            if (destinationVM.Image != null) 
            {
                if (!destinationVM.Image.isValidSize(1000))
                {
                    ModelState.AddModelError("Image", "Image maximum allowed size: 1 mb");
                }
                if (!destinationVM.Image.isImageType())
                {
					ModelState.AddModelError("Image", "File is not image");
				}
            } else
            {
				ModelState.AddModelError("Image", "Destination must have an image!");
			}
            if (!ModelState.IsValid)
            {
				return View(destinationVM);
			}
            Destination destination = new Destination
            {
                Name = destinationVM.Name,
                Price = destinationVM.Price,
                PostalCode = destinationVM.PostalCode,
                Rating = destinationVM.Rating,
                ImgUrl = await destinationVM.Image.SaveImageFileAsync(PathConstatnts.DestinationImage)
            };
            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
			return RedirectToAction("Index", "AdminHome");
		}
		public async Task<IActionResult>  Delete(int? id) 
        {
            if (id == null) return BadRequest();
            var data = await _context.Destinations.FindAsync(id);
            if (data == null) return NotFound();
            System.IO.File.Delete(Path.Combine(data.ImgUrl));
            _context.Remove(data);
            await _context.SaveChangesAsync();
			return RedirectToAction("Index", "AdminHome");
		}
        public IActionResult Update()
        {
            return View();
        }
    }
}
