using AutoMapper;
using Moq;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Core.src.ValueObject;
using Server.Service.src.DTO;
using Server.Service.src.ServiceImplement;
using Server.Service.src.Shared;

namespace Server.Test.src;

public class UserServiceTest
{
    private static IMapper _mapper;
    private readonly UserService _userService;
    private readonly Mock<IUserRepo> _mockUserRepo = new Mock<IUserRepo>();
    public UserServiceTest()
    {
        if (_mapper == null)
        {
            var mappingConfig = new MapperConfiguration(map =>
            {
                map.AddProfile(new MapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }
        _userService = new UserService(_mockUserRepo.Object, _mapper);
    }

    [Fact]
    public async void GetAllUsersAsync_ShouldInvokeRepoMethod()
    {
        var options = new QueryOptions { PageSize = 120, PageNo = 0, sortType = SortType.byTitle, sortOrder = SortOrder.asc };

        await _userService.GetAll(options);

        _mockUserRepo.Verify(repo => repo.GetAllAsync(options), Times.Once);
    }

    [Fact]
    public async void GetUserByIdAsync_ShouldInvokeRepoMethod()
    {
        PasswordService.HashPassword("password1", out string hashedPassword, out byte[] salt);
        User user = new User(
            "name",
            "email",
            hashedPassword,
            "avatar",
            "address line",
            "city",
            "country",
            "postcode",
            Role.Customer,
            salt
        );
        _mockUserRepo.Setup(repo => repo.GetOneByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

        await _userService.GetOneById(It.IsAny<Guid>());

        _mockUserRepo.Verify(repo => repo.GetOneByIdAsync(It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public async void DeleteUser_ShouldInvokeRepoMethod()
    {
        PasswordService.HashPassword("password1", out string hashedPassword, out byte[] salt);
        User user = new User(
            "name",
            "email",
            hashedPassword,
            "avatar",
            "address line",
            "city",
            "country",
            "postcode",
            Role.Customer,
            salt
        );
        _mockUserRepo.Setup(repo => repo.GetOneByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

        await _userService.DeleteOne(It.IsAny<Guid>());

        _mockUserRepo.Verify(repo => repo.DeleteOneAsync(It.IsAny<User>()), Times.Once);
    }

    [Fact]
    public void EmailAvailable_ShouldInvokeRepoMethod()
    {
        _userService.EmailAvailable(It.IsAny<string>());

        _mockUserRepo.Verify(repo => repo.FindByEmail(It.IsAny<string>()), Times.Once);
    }
}