using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Service.src.DTO;

namespace Server.Service.src.ServiceAbstract;

public interface IReviewService
{
    public Task<IEnumerable<Review>> GetAllReviewsAsync(QueryOptions options);
    public Task<IEnumerable<Review>> GetAllReviewsByUserAsync(QueryOptions options);
    public Task<Review> GetAllReviewsByProductsAsync(Guid reviewId);
    public Task<Review> GetReviewByIdAsync(Guid reviewId);
    public Task<Review> CreateReviewAsync(CreateReviewDTO review);
    public Task<Review> UpdateReviewByIdAsync(Guid reviewId);
    public Task<bool> DeleteReviewByIdAsync(Guid orderId);
}
