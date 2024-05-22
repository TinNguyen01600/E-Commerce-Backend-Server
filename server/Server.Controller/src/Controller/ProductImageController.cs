using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Controller.src.Controller
{
    [ApiController]
    [Route("api/v1/productsImage")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProductImageReadDTO>>> GetAllProductImagesAsync([FromQuery] QueryOptions options)
        {
            return Ok(await _productImageService.GetAll(options));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductImageReadDTO>> GetProductImageByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _productImageService.GetOneById(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost()]
        public async Task<ActionResult<ProductImageReadDTO>> CreateProductImageByIdAsync([FromBody] ProductImageCreateDTO productImg)
        {
            return Ok(await _productImageService.CreateOne(productImg));
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductImageReadDTO>> UpdateProductImageAsync([FromRoute] Guid id, [FromBody] ProductImageUpdateDTO category)
        {
            return Ok(await _productImageService.UpdateOne(id, category));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCategoryAsync([FromRoute] Guid id)
        {
            return Ok(await _productImageService.DeleteOne(id));
        }
    }
}