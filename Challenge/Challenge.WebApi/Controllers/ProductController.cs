using Challenge.ApplicationService;
using Challenge.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            return await _productService.GetProduct(id);
        }

    }
}
