using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SolarLabDR.AppServices.Context.Image.Service;
using SolarLabDR.Contracts.Image;
using System.Net;
using System.Net.Mime;

namespace SolarLabDR.Api.Controllers
{

    [Route("api/Images")]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var image = await _imageService.GetByIdAsync(id, cancellationToken);

            return File(image.bytes, "image/png");
        }

        [HttpGet("person/{userId:guid}")]
        public async Task<IActionResult> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var imagesResponseList = await _imageService.GetByUserIdAsync(userId, cancellationToken);
            var result = imagesResponseList.Select(x => "https://localhost:7130/api/Images/" + x.Id.ToString()).ToList();

            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpPost("uplodByteArray")]
        public async Task<IActionResult> PostByteArrayAsync([FromBody] ImageRequest model, CancellationToken cancellationToken)
        {
            await _imageService.CreateAsync(model, cancellationToken);
            return StatusCode((int)HttpStatusCode.Created);
        }


        [HttpPost("uplodImage")]
        public async Task<IActionResult> PostImageAsync(Guid userId, IFormFile file, CancellationToken cancellationToken)
        {
            //TODO валидация
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream, cancellationToken);


                var model = new ImageRequest() 
                {
                    PersonId = userId,
                    bytes = memoryStream.ToArray()
                };

                await _imageService.CreateAsync(model, cancellationToken);
                return StatusCode((int)HttpStatusCode.Created);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _imageService.DeletedAsync(id, cancellationToken);

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
