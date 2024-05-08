using Server.Core.src.Entity;

namespace Server.Core.src.RepoAbstract;

public interface IProductRepo : IBaseRepo<Product>
{
    IEnumerable<Product> GetByCategory(Guid categoryId);
    IEnumerable<Product> GetMostPurchased(int topNumber);
}