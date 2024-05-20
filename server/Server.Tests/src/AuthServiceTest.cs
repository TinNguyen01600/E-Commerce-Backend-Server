using AutoMapper;
using Moq;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Core.src.ValueObject;
using Server.Service.src.ServiceAbstract.Authentication;
using Server.Service.src.ServiceImplement.Authentication;
using Server.Service.src.Shared;

namespace Server.Test.src;

public class AuthServiceTest
{
    private static IMapper _mapper;
    private readonly AuthService _authService;
    private readonly Mock<IUserRepo> _mockUserRepo = new Mock<IUserRepo>();
    private readonly Mock<ITokenService> _mockTokenService = new Mock<ITokenService>();
    public AuthServiceTest()
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
        _authService = new AuthService(_mockUserRepo.Object, _mockTokenService.Object, _mapper);
    }
    [Fact]
    public async void GetCurrentProfile_ShouldInvokeRepoMethod()
    {
        PasswordService.HashPassword("SuperAdmin1234", out string hashedPassword, out byte[] salt);
        User user = new User(
            "name",
            "email",
            "hashedPassword",
            "avatar",
            "address line",
            "city",
            "country",
            "postcode",
            Role.Customer,
            salt
        );
        _mockUserRepo.Setup(repo => repo.GetOneByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);

        await _authService.GetCurrentProfile(It.IsAny<Guid>());

        _mockUserRepo.Verify(repo => repo.GetOneByIdAsync(It.IsAny<Guid>()), Times.Once);
    }
}