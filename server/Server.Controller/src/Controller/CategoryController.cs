using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Controller.src.Controller
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryServices = categoryService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CategoryReadDTO>>> GetAllCategoriesAsync([FromQuery] QueryOptions options)
        {
            return Ok(await _categoryServices.GetAll(options));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryReadDTO>> GetCategoryByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _categoryServices.GetOneById(id));
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoryReadDTO>> CreateCategoryAsync([FromBody] CategoryCreateDTO category)
        {
            return CreatedAtAction(nameof(CreateCategoryAsync), await _categoryServices.CreateOne(category));
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoryReadDTO>> UpdateCategoryAsync([FromRoute] Guid id, [FromBody] CategoryUpdateDTO category)
        {
            return Ok(await _categoryServices.UpdateOne(id, category));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<bool>> DeleteCategoryAsync([FromRoute] Guid id)
        {
            return Ok(await _categoryServices.DeleteOne(id));
        }
    }
}