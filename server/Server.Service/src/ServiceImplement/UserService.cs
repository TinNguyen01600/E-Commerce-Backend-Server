using AutoMapper;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Service.src.ServiceImplement
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        protected IMapper _mapper;

        public UserService(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public Task<bool> CheckEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserReadDTO> CreateAdminAsync(UserCreateDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<UserReadDTO> CreateCustomerAsync(UserCreateDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserReadDTO>> GetAllUsersAsync(QueryOptions options)
        {
            var r = await _userRepo.GetAllAsync(options);
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserReadDTO>>(r);
        }

        public Task<UserReadDTO> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserByIdAsync(UserUpdateDTO user)
        {
            throw new NotImplementedException();
        }
    }
}