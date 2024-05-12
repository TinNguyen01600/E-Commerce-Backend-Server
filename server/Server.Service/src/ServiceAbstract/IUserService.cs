using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Service.src.DTO;

namespace Server.Service.src.ServiceAbstract
{
    public interface IUserService : IBaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>
    {
        // bool UpdatePassword(PasswordChangeForm passwordChangeForm, Guid id);
        Task<bool> EmailAvailable(string email);
        // UserReadDTO UpdateRole(Guid id, UserRoleUpdateDTO userRoleUpdateDto);
    }
}