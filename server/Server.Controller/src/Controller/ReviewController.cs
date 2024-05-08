using Server.Core.src.Common;
using Server.Core.src.Entity;
// using Server.Service.src.DTO;
// using Server.Service.src.ServiceAbstraction;
using Microsoft.AspNetCore.Mvc;
using Server.Service.src.ServiceAbstract;
using Server.Service.src.DTO;

namespace Server.Controller.src.Controller;

[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet("/api/v1/reviews")]
    public async Task<IEnumerable<Review>> GetAllReviewsAsync([FromQuery] QueryOptions options)
    {
        return await _reviewService.GetAllReviewsAsync(options);
    }

    [HttpGet("/api/v1/reviews/user")]
    public async Task<IEnumerable<Review>> GetAllReviewsByUserAsync([FromQuery] QueryOptions options)
    {
        return await _reviewService.GetAllReviewsByUserAsync(options);
    }

    [HttpGet("/api/v1/reviews/product/{id}")]
    public async Task<Review> GetAllReviewsByProductsAsync([FromRoute] Guid id)
    {
        return await _reviewService.GetAllReviewsByProductsAsync(id);
    }

    [HttpGet("/api/v1/reviews/{id}")]
    public async Task<Review> GetReviewByIdAsync([FromRoute] Guid id)
    {
        return await _reviewService.GetReviewByIdAsync(id);
    }

    [HttpPost("/api/v1/reviews")]
    public async Task<Review> CreateReviewAsync([FromBody] CreateReviewDTO review)
    {
        return await _reviewService.CreateReviewAsync(review);
    }

    [HttpPatch("/api/v1/reviews/{id}")]
    public async Task<Review> UpdateReviewByIdAsync([FromRoute] Guid id)
    {
        return await _reviewService.UpdateReviewByIdAsync(id);
    }

    [HttpDelete("/api/v1/reviews/{id}")]
    public async Task<bool> DeleteReviewByIdAsync([FromRoute] Guid id)
    {
        return await _reviewService.DeleteReviewByIdAsync(id);
    }
}