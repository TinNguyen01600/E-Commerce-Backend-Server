using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Service.src.ServiceImplement;

public class ReviewService : IReviewService
{
    private readonly IReviewService _reviewService;

    public ReviewService(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    public Task<Review> CreateReviewAsync(Review review)
    {
        throw new NotImplementedException();
    }

    public Task<Review> CreateReviewAsync(CreateReviewDTO review)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteReviewByIdAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Review>> GetAllReviewsAsync(QueryOptions options)
    {
        throw new NotImplementedException();
    }

    public Task<Review> GetAllReviewsByProductsAsync(Guid reviewId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Review>> GetAllReviewsByUserAsync(QueryOptions options)
    {
        throw new NotImplementedException();
    }

    public Task<Review> GetReviewByIdAsync(Guid reviewId)
    {
        throw new NotImplementedException();
    }

    public Task<Review> UpdateReviewByIdAsync(Guid reviewId)
    {
        throw new NotImplementedException();
    }

    Task<Review> IReviewService.GetAllReviewsByProductsAsync(Guid reviewId)
    {
        throw new NotImplementedException();
    }

    Task<Review> IReviewService.GetReviewByIdAsync(Guid reviewId)
    {
        throw new NotImplementedException();
    }

    Task<Review> IReviewService.UpdateReviewByIdAsync(Guid reviewId)
    {
        throw new NotImplementedException();
    }
}
