using Server.Core.src.Entity;
using Server.Core.src.Common;

namespace Server.Core.src.RepoAbstract
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<bool> ChangePasswordAsync(User user, string newPassword);
        Task<bool> CheckEmailAsync(string email);
        User FindByEmail(string email);
    }
}