using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Infrastructure.src.Database;

namespace Server.Infrastructure.src.Repository;

public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
{
    public CategoryRepo(AppDbContext databaseContext) : base(databaseContext)
    {
    }
}