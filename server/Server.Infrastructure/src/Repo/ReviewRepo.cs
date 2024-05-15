using Microsoft.EntityFrameworkCore;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Infrastructure.src.Database;
using Server.Infrastructure.src.Repository;

namespace Server.Infrastructure.src.Repo;

public class ReviewRepo : BaseRepo<Review>, IReviewRepo
{
    public ReviewRepo(AppDbContext databaseContext) : base(databaseContext)
    {
    }

    public override async Task<IEnumerable<Review>> GetAllAsync(QueryOptions options)
    {
        return _data.Include("User").Skip(options.PageNo).Take(options.PageSize).ToArray();
    }

    public override async Task<Review> GetOneByIdAsync(Guid id)
    {
        var allData = _data.Include("User");
        return allData.FirstOrDefault(order => order.Id == id);
    }

    public async Task<IEnumerable<Review>> GetByProduct(Guid productId)
    {
        return _data.Include("User").Where(reviews => reviews.ProductId == productId);
    }
}