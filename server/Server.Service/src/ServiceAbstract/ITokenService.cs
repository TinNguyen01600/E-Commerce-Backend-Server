using Server.Core.src.Entity;

namespace Server.Service.src.ServiceAbstract.Authentication;

public interface ITokenService
{
    public string GetToken(User user);
    // public Guid VerifyToken(string token);
}