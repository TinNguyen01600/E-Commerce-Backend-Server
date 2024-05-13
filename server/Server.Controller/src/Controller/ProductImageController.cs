using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Controller.src.Controller
{
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet("api/v1/productsImage")] 
        public async Task<IEnumerable<ProductImageReadDTO>> GetAllProductImagesAsync([FromQuery] QueryOptions options)
        {
            Console.WriteLine("GetAllCategoriesAsync");
            try
            {
                return await _productImageService.GetAll(options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("api/v1/productsImage/{id}")] 
        public async Task<ProductImageReadDTO> GetProductImageByIdAsync([FromRoute] Guid id)
        {
            return await _productImageService.GetOneById(id);
        }

        [HttpPost("api/v1/productsImage")] 
        public async Task<ProductImageReadDTO> CreateProductImageByIdAsync([FromBody] ProductImageCreateDTO productImg)
        {
            return await _productImageService.CreateOne(productImg);
        }
        [HttpPatch("{id:guid}")]
        public async Task<ProductImageReadDTO> UpdateProductImageAsync([FromRoute] Guid id, [FromBody] ProductImageUpdateDTO category)
        {
            return await _productImageService.UpdateOne(id, category);
        }
        [HttpDelete("{id:guid}")] 
        public async Task<bool> DeleteCategoryAsync([FromRoute] Guid id)
        {
            return await _productImageService.DeleteOne(id);
        }
    }
}