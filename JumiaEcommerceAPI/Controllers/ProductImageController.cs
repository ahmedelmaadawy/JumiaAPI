using JumiaEcommerceAPI.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JumiaEcommerceAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _service;

        public ProductImageController(IProductImageService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult GetImageById(int imageId)
        {
            if (imageId == 0)
                return BadRequest("Wrong Image Id");
            try
            {
                var image = _service.GetImageById(imageId);
                return File(image.Image, "image/jpg");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public ActionResult AddImageToProduct([FromForm] int productId, [FromForm] IFormFile image)
        {
            if (productId == 0 || image == null)
                return BadRequest("Image Cant be null and id must not be equal 0");
            try
            {
                _service.AddImageToProduct(productId, image);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

    }
}
