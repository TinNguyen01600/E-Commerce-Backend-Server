using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;


namespace Server.Controller.src.Controller
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("api/v1/users")] // define endpoint: /users?page=1&pageSize=10
        public async Task<IEnumerable<UserReadDTO>> GetAllUsersAsync([FromQuery] QueryOptions options)
        {
            try
            {
                return await _userService.GetAllUsersAsync(options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("api/v1/user/{id}")]
        public async Task<UserReadDTO> GetUserByIdAsync([FromRoute] Guid id)
        {
            try
            {
                return await _userService.GetUserByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("api/v1/user/")]
        public async Task<UserReadDTO> CreateCustomerAsync([FromBody] UserCreateDTO user)
        {
            try
            {
                return await _userService.CreateCustomerAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("api/v1/user/{id}")]
        public async Task<bool> DeleteUserByIdAsync([FromRoute] Guid id)
        {
            try
            {
                return await _userService.DeleteUserByIdAsync(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPatch("api/v1/user/{id}")]
        public async Task<bool> UpdateUserByIdAsync([FromBody] UserUpdateDTO user)
        {
            try
            {
                return await _userService.UpdateUserByIdAsync(user);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("api/v1/user/change_password/{id}")]
        public async Task<bool> ChangePassword([FromBody] UserUpdateDTO user)
        {
            try
            {
                return await _userService.UpdateUserByIdAsync(user);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}