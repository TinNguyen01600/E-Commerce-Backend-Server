using Server.Core.src.Common;
using Server.Core.src.Entity;
using Microsoft.AspNetCore.Mvc;
using Server.Service.src.ServiceAbstract;
using Server.Service.src.DTO;
using Server.Service.src.Shared;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Server.Controller.src.Controller;

[ApiController]
[Route("/api/v1/reviews")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly IAuthorizationService _authorizationService;
    public ReviewController(IReviewService reviewService, IAuthorizationService authorizationService)
    {
        _reviewService = reviewService;
        _authorizationService = authorizationService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<ReviewReadDTO>>> GetAllReviewsAsync([FromQuery] QueryOptions options)
    {
        return Ok(await _reviewService.GetAll(options));
    }

    [HttpGet("product/{id}")]
    public async Task<ActionResult<IEnumerable<ReviewReadDTO>>> GetAllReviewsByProductsAsync([FromRoute] Guid id)
    {
        return Ok(await _reviewService.GetByProduct(id));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReviewReadDTO>> GetReviewByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _reviewService.GetOneById(id));
    }

    [Authorize(Roles = "Customer")]
    [HttpPost()]
    public async Task<ActionResult<ReviewReadDTO>> CreateReviewAsync([FromBody] ReviewCreateDTO review)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return CreatedAtAction(nameof(CreateReviewAsync), await _reviewService.CreateOne(Guid.Parse(userId), review));
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<ReviewReadDTO>> UpdateReviewByIdAsync([FromRoute] Guid id, [FromBody] ReviewUpdateDTO reviewUpdateDto)
    {
        ReviewReadDTO? foundReview = await _reviewService.GetOneById(id);
        if (foundReview is null)
        {
            throw CustomException.NotFoundException("Review not found");
        }
        else
        {
            return Ok(await _reviewService.UpdateOne(id, reviewUpdateDto));
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteReviewByIdAsync([FromRoute] Guid id)
    {
        ReviewReadDTO? foundReview = await _reviewService.GetOneById(id);
        if (foundReview is null)
        {
            throw CustomException.NotFoundException("Review not found");
        }
        else
        {
            return Ok(await _reviewService.DeleteOne(id));
        }
    }
}