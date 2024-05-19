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

        [Authorize(Roles = "Admin")]
        [HttpGet("api/v1/users/{id}")]
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
        [HttpPost("api/v1/users/")]
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
        [HttpDelete("api/v1/users/{id}")]
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
        [HttpPatch("api/v1/users/{id}")]
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
        [HttpPatch("api/v1/users/update-password/{id:guid}")]
        public async Task<bool> UpdatePassword([FromRoute] Guid id, [FromBody] PasswordChangeForm passwordChangeForm)
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
                    return await _userService.UpdatePassword(passwordChangeForm, id);
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
        [HttpPost("api/v1/users/email-avaiable")]
        public async Task<bool> EmailAvailable([FromBody] string email)
        {
            return await _userService.EmailAvailable(email);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("api/v1/users/update-role/{id:guid}")]
        public async Task<UserReadDTO> UpdateRole([FromRoute] Guid id, [FromBody] UserRoleUpdateDTO userRoleUpdateDTO)
        {
            return await _userService.UpdateRole(id, userRoleUpdateDTO);
        }
    }
}