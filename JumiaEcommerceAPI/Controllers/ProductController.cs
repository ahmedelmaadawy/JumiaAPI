using JumiaEcommerceAPI.BusinessLogic.DTOs;
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
                return Ok(products);

            }
            else
            {
                return BadRequest("NO Products Found");
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
