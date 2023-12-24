namespace TravellingMVC.Helpers
{
	public class PathConstatnts
	{
		public static string RootPath { get; set; }
		public static string DestinationImage => Path.Combine("savedimages", "destination");
	}
}
