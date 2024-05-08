using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Infrastructure.src.Database;

namespace Server.Infrastructure.src.Repository
{
    public class ProductImageRepo : BaseRepo<ProductImage>, IProductImageRepo
    {
        public ProductImageRepo(AppDbContext context) : base(context)
        {
        }
    }
}