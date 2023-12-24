using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravellingMVC.ViewModels.DestinationVM
{
    public class DestinationListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostalCode { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public int Rating { get; set; }
    }
}
