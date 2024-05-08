using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract.Authentication;

namespace Server.Controller.src.Controller;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("api/v1/auth/login")]
    public string Login([FromBody] UserCredential credential)
    {
        Console.WriteLine("In Authentication");
        return _authService.Login(credential);
    }

    [Authorize]
    [HttpGet("api/v1/auth/profile")]
    public async Task<UserReadDTO> GetCurrentProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return await _authService.GetCurrentProfile(Guid.Parse(userId));
    }
}