using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;
using Server.Service.src.Shared;


namespace Server.Controller.src.Controller
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;

        public UserController(IUserService userService, IAuthorizationService authorizationService)
        {
            _userService = userService;
            _authorizationService = authorizationService;
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
            UserReadDTO foundUser = await _userService.GetOneById(id);
            if (foundUser is null)
            {
                throw CustomException.NotFoundException("User not found");
            }
            else
            {
                var authorizationResult = _authorizationService
               .AuthorizeAsync(HttpContext.User, foundUser, "AdminOrOwnerAccount")
               .GetAwaiter()
               .GetResult();

                if (authorizationResult.Succeeded)
                {
                    return await _userService.DeleteOne(id);
                }
                else if (User.Identity!.IsAuthenticated)
                {
                    throw CustomException.UnauthorizedException("Not authenticated");
                }
                else
                {
                    throw CustomException.UnauthorizedException("Not authorized");
                }
            }
        }
        [HttpPatch("api/v1/user/{id}")]
        public async Task<UserReadDTO> UpdateUserByIdAsync([FromRoute] Guid id, [FromBody] UserUpdateDTO updateUser)
        {
            UserReadDTO foundUser = await _userService.GetOneById(id);
            if (foundUser is null)
            {
                throw CustomException.NotFoundException("User not found");
            }
            else
            {
                var authorizationResult = _authorizationService
               .AuthorizeAsync(HttpContext.User, foundUser, "AdminOrOwnerAccount")
               .GetAwaiter()
               .GetResult();

                if (authorizationResult.Succeeded)
                {
                    return await _userService.UpdateOne(id, updateUser);
                }
                else if (User.Identity!.IsAuthenticated)
                {
                    throw CustomException.UnauthorizedException("Not authenticated");
                }
                else
                {
                    throw CustomException.UnauthorizedException("Not authorized");
                }
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