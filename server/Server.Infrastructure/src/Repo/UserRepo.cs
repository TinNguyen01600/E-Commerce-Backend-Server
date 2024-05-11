using Microsoft.EntityFrameworkCore;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Infrastructure.src.Database;
using Server.Infrastructure.src.Repository;

namespace Server.Infrastructure.src.Repo
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo(AppDbContext context) : base(context)
        {
        }
        public User FindByEmail(string email)
        {
            return _data.AsNoTracking().FirstOrDefault(user => user.Email == email);
        }
    }
}