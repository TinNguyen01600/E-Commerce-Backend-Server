using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Service.src.DTO;

namespace Server.Service.src.ServiceAbstract.Authentication;

public interface IAuthService
{
    public string Login(UserCredential credential);
    public Task<UserReadDTO> GetCurrentProfile(Guid id);
}