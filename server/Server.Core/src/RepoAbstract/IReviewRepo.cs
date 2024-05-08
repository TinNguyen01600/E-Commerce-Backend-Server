using Server.Core.src.Common;
using Server.Core.src.Entity;

namespace Server.Core.src.RepoAbstract;

public interface IReviewRepo
{
    public Task<List<Review>> GetAllReviewsAsync(QueryOptions options);
    public Task<List<Review>> GetAllReviewsByUserAsync(QueryOptions options);
    public Task<Review> GetAllReviewsByProductsAsync(Guid reviewId);
    public Task<Review> GetReviewByIdAsync(Guid reviewId);
    public Task<Review> CreateReviewAsync(Review review);
    public Task<Review> UpdateReviewByIdAsync(Guid reviewId);
    public Task<bool> DeleteReviewByIdAsync(Guid orderId);
}
