using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Service.src.DTO;

namespace Server.Service.src.ServiceAbstract
{
    public interface IUserService : IBaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO>
    {
        Task<bool> UpdatePassword(PasswordChangeForm passwordChangeForm, Guid id);
        Task<bool> EmailAvailable(string email);
        Task<UserReadDTO> UpdateRole(Guid id, UserRoleUpdateDTO userRoleUpdateDto);
    }
}