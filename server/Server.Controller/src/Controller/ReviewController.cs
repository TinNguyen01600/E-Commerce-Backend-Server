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
    [HttpGet("/api/v1/reviews")]
    public async Task<IEnumerable<ReviewReadDTO>> GetAllReviewsAsync([FromQuery] QueryOptions options)
    {
        return await _reviewService.GetAll(options);
    }

    [HttpGet("/api/v1/reviews/product/{id}")]
    public async Task<IEnumerable<ReviewReadDTO>> GetAllReviewsByProductsAsync([FromRoute] Guid id)
    {
        return await _reviewService.GetByProduct(id);
    }

    [HttpGet("/api/v1/reviews/{id}")]
    public async Task<ReviewReadDTO> GetReviewByIdAsync([FromRoute] Guid id)
    {
        return await _reviewService.GetOneById(id);
    }

    [Authorize(Roles = "Customer")]
    [HttpPost("/api/v1/reviews")]
    public async Task<ReviewReadDTO> CreateReviewAsync([FromBody] ReviewCreateDTO review)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return await _reviewService.CreateOne(Guid.Parse(userId), review);
    }

    [HttpPatch("/api/v1/reviews/{id}")]
    public async Task<ReviewReadDTO> UpdateReviewByIdAsync([FromRoute] Guid id, [FromBody] ReviewUpdateDTO reviewUpdateDto)
    {
        ReviewReadDTO? foundReview = await _reviewService.GetOneById(id);
        if (foundReview is null)
        {
            throw CustomException.NotFoundException("Review not found");
        }
        else
        {
            var authorizationResult = _authorizationService
           .AuthorizeAsync(HttpContext.User, foundReview, "AdminOrOwnerReview")
           .GetAwaiter()
           .GetResult();

            if (authorizationResult.Succeeded)
            {
                return await _reviewService.UpdateOne(id, reviewUpdateDto);
            }
            else if (User.Identity!.IsAuthenticated)
            {
                throw CustomException.UnauthorizedException("Not authenticated");
            }
            else
            {
                throw CustomException.UnauthorizedException("Not authorized");
            }
        }
    }

    [HttpDelete("/api/v1/reviews/{id}")]
    public async Task<bool> DeleteReviewByIdAsync([FromRoute] Guid id)
    {
        ReviewReadDTO? foundReview = await _reviewService.GetOneById(id);
        if (foundReview is null)
        {
            throw CustomException.NotFoundException("Review not found");
        }
        else
        {
            var authorizationResult = _authorizationService
           .AuthorizeAsync(HttpContext.User, foundReview, "AdminOrOwnerReview")
           .GetAwaiter()
           .GetResult();

            if (authorizationResult.Succeeded)
            {
                return await _reviewService.DeleteOne(id);
            }
            else if (User.Identity!.IsAuthenticated)
            {
                throw CustomException.UnauthorizedException("Not authenticated");
            }
            else
            {
                throw CustomException.UnauthorizedException("Not authorized");
            }
        }
    }
}