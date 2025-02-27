using AI_Apps.Models;
using AI_Apps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AI_Apps.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IImageUploadService _imageUploadService;


        //injecting image upload service using DI
        public ImageUploadController(IImageUploadService imageUploadService)
        {
            _imageUploadService = imageUploadService;
        }

        public async Task<ActionResult> UploadImage([FromForm] IFormFile image)
        {
            try
            {
                string filePath = await _imageUploadService.UploadImageAsync(image);
                return Ok(new UploadResponse { IsSuccess = true, Message = "Image uploaded successfully.", FilePath = filePath });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new UploadResponse { IsSuccess = false, Message = ex.Message });
            }
        } 
    }
}
