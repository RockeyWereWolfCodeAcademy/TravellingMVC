namespace TravellingMVC.Helpers
{
	public static class ImageFileHelper
	{
		public static async Task<string> SaveImageFileAsync(this IFormFile file, string path)
		{
			string extension = Path.GetExtension(file.FileName);
			string fileToSaveName = Path.GetFileNameWithoutExtension(file.FileName);
			fileToSaveName = Path.Combine(path, Path.GetRandomFileName() + fileToSaveName + extension);
			using (FileStream fs = File.Create(Path.Combine(PathConstatnts.RootPath, fileToSaveName)))
			{
				await file.CopyToAsync(fs);
			}
			return fileToSaveName;
		}
		public static bool isValidSize(this IFormFile file, float sizeKb) 
			=> file.FileName.Length <= sizeKb;
		public static bool isImageType(this IFormFile file)
			=> file.ContentType.Contains("image");
	}
}
