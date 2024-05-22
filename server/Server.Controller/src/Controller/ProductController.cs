using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Controller.src.Controller
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productServices;

        public ProductController(IProductService productService)
        {
            _productServices = productService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetAllProductsAsync([FromQuery] QueryOptions options)
        {
            return Ok(await _productServices.GetAllProductsAsync(options));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDTO>> GetProductByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _productServices.GetProductById(id));
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetAllProductsByCategoryAsync([FromRoute] Guid categoryId)
        {
            return Ok(await _productServices.GetAllProductsByCategoryAsync(categoryId));
        }

        [HttpGet("top/{topNumber:int}")]
        public async Task<ActionResult<IEnumerable<ProductReadDTO>>> GetMostPurchased([FromRoute] int top)
        {
            return Ok(await _productServices.GetMostPurchasedProductsAsync(top));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost()]
        public async Task<ActionResult<ProductReadDTO>> CreateProductAsync([FromBody] ProductCreateDTO product)
        {
            return CreatedAtAction(nameof(CreateProductAsync), await _productServices.CreateProduct(product));
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductReadDTO>> UpdateProductAsync([FromRoute] Guid id, [FromBody] ProductUpdateDTO category)
        {
            return Ok(await _productServices.UpdateProduct(id, category));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProductAsync([FromRoute] Guid id)
        {
            return Ok(await _productServices.DeleteProduct(id));
        }
    }
}