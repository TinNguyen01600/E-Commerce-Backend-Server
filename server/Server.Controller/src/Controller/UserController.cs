using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [Authorize(Roles = "Admin")]
        [HttpGet("api/v1/users")]
        public async Task<IEnumerable<UserReadDTO>> GetAllUsersAsync([FromQuery] QueryOptions options)
        {
            try
            {
                return await _userService.GetAll(options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("api/v1/user/{id}")]
        public async Task<UserReadDTO> GetUserByIdAsync([FromRoute] Guid id)
        {
            try
            {
                return await _userService.GetOneById(id);
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
                return await _userService.CreateOne(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("api/v1/user/{id}")]
        public async Task<bool> DeleteUserByIdAsync([FromRoute] Guid id)
        {
            try
            {
                return await _userService.DeleteOne(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPatch("api/v1/user/{id}")]
        public async Task<UserReadDTO> UpdateUserByIdAsync([FromRoute] Guid id, [FromBody] UserUpdateDTO updateUser)
        {
            try
            {
                return await _userService.UpdateOne(id, updateUser);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // [HttpPatch("api/v1/user/change_password/{id}")]
        // public async Task<bool> ChangePassword([FromBody] UserUpdateDTO user)
        // {
        //     try
        //     {
        //         return await _userService.UpdateUserByIdAsync(user);

        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception(ex.Message);
        //     }
        // }
    }
}