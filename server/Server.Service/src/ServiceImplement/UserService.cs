using AutoMapper;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Core.src.ValueObject;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;
using Server.Service.src.Shared;

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

        // --------------------------------------------------------------
        public override async Task<UserReadDTO> CreateOne(UserCreateDTO userCreateDto)
        {
            PasswordService.HashPassword(userCreateDto.Password, out string hashedPassword, out byte[] salt);
            var user = _mapper.Map<UserCreateDTO, User>(userCreateDto);
            user.Role = Role.Customer;
            user.Password = hashedPassword;
            user.Salt = salt;
            var result = await _repo.CreateOneAsync(user);
            return _mapper.Map<User, UserReadDTO>(result);
        }
        public Task<bool> EmailAvailable(string email)
        {
            var foundEmail = _repo.FindByEmail(email);
            if (foundEmail is null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
        public async Task<bool> UpdatePassword(PasswordChangeForm passwordChangeForm, Guid id)
        {
            var user = await _repo.GetOneByIdAsync(id);
            if (user is null)
            {
                throw CustomException.NotFoundException();
            }
            bool passwordMatch = PasswordService.VerifyPassword(passwordChangeForm.CurrentPassword, user.Password, user.Salt);
            if (!passwordMatch)
            {
                throw CustomException.NotFoundException("Current password incorrect");
            }
            else
            {
                PasswordService.HashPassword(passwordChangeForm.NewPassword, out string hashedNewPassword, out byte[] newSalt);
                user.Password = hashedNewPassword;
                user.Salt = newSalt;
                await _repo.UpdateOneAsync(user);
                return true;
            }
        }

        public async Task<UserReadDTO> UpdateRole(Guid id, UserRoleUpdateDTO userRoleUpdateDto)
        {
            var foundUser = await _repo.GetOneByIdAsync(id);
            if (foundUser is not null)
            {
                var result = await _repo.UpdateOneAsync(_mapper.Map(userRoleUpdateDto, foundUser));
                return _mapper.Map<User, UserReadDTO>(result);
            }
            else
            {
                throw CustomException.NotFoundException("Id not found");
            }
        }
    }
}