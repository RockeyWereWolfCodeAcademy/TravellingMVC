using Microsoft.EntityFrameworkCore;
using TravellingMVC.Models;

namespace TravellingMVC.Contexts
{
	public class TravellingDbContext : DbContext
	{
		public  TravellingDbContext(DbContextOptions<TravellingDbContext> options) : base(options) { }
		public DbSet<Destination> Destinations { get; set; }
	}
}
