namespace AI_Apps.Services
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IFormFile image);
    }
}
