
namespace AI_Apps.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageUploadService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                throw new ArgumentException("No image uploaded.");
            }


            //SANATIZE IMAGE USINg AZURE AI VISION API 
            //If cleaned then save otherwise return error.


            // Define the path to save the image
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, image.FileName);

            // Save the image to the specified path
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}
