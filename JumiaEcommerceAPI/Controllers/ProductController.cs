using JumiaEcommerceAPI.BusinessLogic.DTOs.Product;
using JumiaEcommerceAPI.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JumiaEcommerceAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var products = _service.GetAllProducts();
            if (products != null)
            {
                foreach (var product in products)
                {
                    int imgId = 0;
                    var res = int.TryParse(product.ImageUrl, out imgId);
                    if (!res)
                        product.ImageUrl = "";
                    else
                        product.ImageUrl = Url.Action("GetImageById", "ProductImage", new { imageId = imgId }, Url.ActionContext.HttpContext.Request.Scheme);
                }
                return Ok(products);
            }
            else
            {
                return BadRequest("NO Products Found");
            }
        }
        [HttpGet("{id:int}")]
        public ActionResult GetProductById(int id)
        {
            try
            {
                var product = _service.GetById(id);
                int imgId = 0;
                for (var i = 0; i < product.ImagesUrl.Count(); i++)
                {
                    var res = int.TryParse(product.ImagesUrl[i], out imgId);
                    if (res)
                        product.ImagesUrl[i] = Url.Action("GetImageById", "ProductImage", new { imageId = imgId }, Url.ActionContext.HttpContext.Request.Scheme);
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult AddProduct([FromBody] ProductToAddDTO productToAdd)
        {

            if (productToAdd is not null)
            {
                try
                {
                    _service.AddProduct(productToAdd);
                    return Created();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", $"couldnt add to database{ex.Message}");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
