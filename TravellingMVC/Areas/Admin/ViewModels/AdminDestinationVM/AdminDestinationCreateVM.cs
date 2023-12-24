using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravellingMVC.Areas.Admin.ViewModels.AdminDestinationVM
{
    public class AdminDestinationCreateVM
    {
		[Required, MaxLength(16)]
		public string Name { get; set; }
		[Required]
		public int PostalCode { get; set; }
		[Required, Column(TypeName = "smallmoney")]
		public decimal Price { get; set; }
		[Required]
		public IFormFile Image { get; set; }
		[Required, Range(0, 5)]
		public int Rating { get; set; }
	}
}
