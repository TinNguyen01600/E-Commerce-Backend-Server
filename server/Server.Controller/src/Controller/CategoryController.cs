using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Controller.src.Controller
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryServices = categoryService;
        }

        [HttpGet("api/v1/categories")] 
        public async Task<IEnumerable<CategoryReadDTO>> GetAllCategoriesAsync([FromQuery] QueryOptions options)
        {
            Console.WriteLine("GetAllCategoriesAsync");
            try
            {
                return await _categoryServices.GetAll(options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("api/v1/categories/{id}")] 
        public async Task<CategoryReadDTO> GetCategoryByIdAsync([FromRoute] Guid id)
        {
            return await _categoryServices.GetOneById(id);
        }

        [HttpPost("api/v1/categories")]
        [Authorize(Roles = "Admin")]
        public async Task<CategoryReadDTO> CreateCategoryAsync([FromBody] CategoryCreateDTO category)
        {
            return await _categoryServices.CreateOne(category);
        }
        [HttpPatch("api/v1/categories/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<CategoryReadDTO> UpdateCategoryAsync([FromRoute] Guid id, [FromBody] CategoryUpdateDTO category)
        {
            return await _categoryServices.UpdateOne(id, category);
        }
        [HttpDelete("api/v1/categories/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> DeleteCategoryAsync([FromRoute] Guid id)
        {
            return await _categoryServices.DeleteOne(id);
        }
    }
}