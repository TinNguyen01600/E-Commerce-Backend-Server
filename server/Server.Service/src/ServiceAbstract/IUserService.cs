using Server.Core.src.Common;
using Server.Service.src.DTO;

namespace Server.Service.src.ServiceAbstract
{
    public interface IUserService
    {
        Task<UserReadDTO> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserReadDTO>> GetAllUsersAsync(QueryOptions options);
        Task<bool> UpdateUserByIdAsync(UserUpdateDTO user);
        Task<bool> DeleteUserByIdAsync(Guid id);
        Task<UserReadDTO> CreateCustomerAsync(UserCreateDTO user);
        Task<UserReadDTO> CreateAdminAsync(UserCreateDTO user);
        Task<bool> CheckEmailAsync(string email);

    }
}