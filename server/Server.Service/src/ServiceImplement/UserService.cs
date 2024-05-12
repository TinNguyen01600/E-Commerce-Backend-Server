using AutoMapper;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Service.src.ServiceImplement
{
    public class UserService : BaseService<User, UserReadDTO, UserCreateDTO, UserUpdateDTO, IUserRepo>, IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper mapper;

        public UserService(IUserRepo userRepo, IMapper mapper) : base(userRepo, mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public Task<UserReadDTO> CreateOne(UserCreateDTO createObject)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteOne(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<UserReadDTO> GetOneById(Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<UserReadDTO> UpdateOne(Guid id, UserUpdateDTO updateObject)
        {
            throw new NotImplementedException();
        }

        // --------------------------------------------------------------
        public Task<bool> EmailAvailable(string email)
        {
            throw new NotImplementedException();
        }
    }
}