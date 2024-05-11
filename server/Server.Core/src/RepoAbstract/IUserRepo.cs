using Server.Core.src.Entity;
using Server.Core.src.Common;

namespace Server.Core.src.RepoAbstract
{
    public interface IUserRepo : IBaseRepo<User>
    {
        User FindByEmail(string email);
    }
}