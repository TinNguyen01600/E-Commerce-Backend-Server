using Server.Core.src.Common;
using Server.Core.src.Entity;

namespace Server.Core.src.RepoAbstract;

public interface IReviewRepo : IBaseRepo<Review>
{
    Task<IEnumerable<Review>> GetByProduct(Guid productId);
}
