using AutoMapper;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract.Authentication;
using Server.Service.src.Shared;

namespace Server.Service.src.ServiceImplement.Authentication;

public class AuthService : IAuthService
{
    private IUserRepo _userRepo;
    private ITokenService _tokenService;
    private IMapper _mapper;

    public AuthService(IUserRepo userRepo, ITokenService tokenService, IMapper mapper)
    {
        _userRepo = userRepo;
        _tokenService = tokenService;
        _mapper = mapper;
    }
    
    public async Task<UserReadDTO> GetCurrentProfile(Guid id)
    {
        var foundUser = await _userRepo.GetOneByIdAsync(id);
        if (foundUser != null)
        {
            return _mapper.Map<User, UserReadDTO>(foundUser);
        }
        throw CustomException.NotFoundException("User not found");
    }

    public string Login(UserCredential credential)
    {
        var foundByEmail = _userRepo.FindByEmail(credential.Email);
        if (foundByEmail is null)
        {
            throw CustomException.NotFoundException("Email not found");
        }
        var isPasswordMatch = PasswordService.VerifyPassword(credential.Password, foundByEmail.Password, foundByEmail.Salt);
        if (isPasswordMatch)
        {
            return _tokenService.GetToken(foundByEmail);
        }
        throw CustomException.UnauthorizedException("Password incorrect");
    }
}