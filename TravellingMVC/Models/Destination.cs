using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravellingMVC.Models
{
	public class Destination
	{
        public int Id { get; set; }
        [Required, MaxLength(16)]
        public string Name { get; set; }
        [Required]
        public int PostalCode { get; set; }
		[Required, Column(TypeName = "smallmoney")]
		public decimal Price { get; set; }
        [Required]
		public string ImgUrl { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
