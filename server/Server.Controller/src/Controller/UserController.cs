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
    [Route("api/v1/users")]
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
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetAllUsersAsync([FromQuery] QueryOptions options)
        {
            return Ok(await _userService.GetAll(options));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUserByIdAsync([FromRoute] Guid id)
        {
            return Ok(await _userService.GetOneById(id));
        }
        [HttpPost()]
        public async Task<ActionResult<UserReadDTO>> CreateCustomerAsync([FromBody] UserCreateDTO user)
        {
            return CreatedAtAction(nameof(CreateCustomerAsync), await _userService.CreateOne(user));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUserByIdAsync([FromRoute] Guid id)
        {
            UserReadDTO foundUser = await _userService.GetOneById(id);
            if (foundUser is null)
            {
                throw CustomException.NotFoundException("User not found");
            }
            else
            {
                return Ok(await _userService.DeleteOne(id));
            }
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<UserReadDTO>> UpdateUserByIdAsync([FromRoute] Guid id, [FromBody] UserUpdateDTO updateUser)
        {
            UserReadDTO foundUser = await _userService.GetOneById(id);
            if (foundUser is null)
            {
                throw CustomException.NotFoundException("User not found");
            }
            else
            {
                return Ok(await _userService.UpdateOne(id, updateUser));
            }
        }
        [HttpPatch("update-password/{id:guid}")]
        public async Task<ActionResult<bool>> UpdatePassword([FromRoute] Guid id, [FromBody] PasswordChangeForm passwordChangeForm)
        {
            UserReadDTO foundUser = await _userService.GetOneById(id);
            if (foundUser is null)
            {
                throw CustomException.NotFoundException("User not found");
            }
            else
            {
                return Ok(await _userService.UpdatePassword(passwordChangeForm, id));
            }
        }
        [HttpPost("email-avaiable")]
        public async Task<ActionResult<bool>> EmailAvailable([FromBody] string email)
        {
            return Ok(await _userService.EmailAvailable(email));
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("update-role/{id}")]
        public async Task<ActionResult<UserReadDTO>> UpdateRole([FromRoute] Guid id, [FromBody] UserRoleUpdateDTO userRoleUpdateDTO)
        {
            return Ok(await _userService.UpdateRole(id, userRoleUpdateDTO));
        }
    }
}