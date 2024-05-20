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

public class ReviewServiceTest
{
    private static IMapper _mapper;
    private readonly ReviewService _reviewService;
    private readonly Mock<IReviewRepo> _mockReviewRepo = new Mock<IReviewRepo>();
    private readonly Mock<IProductRepo> _mockProductRepo = new Mock<IProductRepo>();
    private readonly Mock<IUserRepo> _mockUserRepo = new Mock<IUserRepo>();
    public ReviewServiceTest()
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
        _reviewService = new ReviewService(_mockReviewRepo.Object, _mapper, _mockProductRepo.Object, _mockUserRepo.Object);
    }

    [Fact]
    public async void GetAllReviews_ShouldInvokeRepoMethod()
    {
        var options = new QueryOptions { PageSize = 120, PageNo = 0, sortType = SortType.byTitle, sortOrder = SortOrder.asc };

        await _reviewService.GetAll(options);

        _mockReviewRepo.Verify(repo => repo.GetAllAsync(options), Times.Once);
    }

    [Fact]
    public async void GetReviewById_ShouldInvokeRepoMethod()
    {
        Review review = new Review { Rating = 3, Comment = "Comment" };
        _mockReviewRepo.Setup(repo => repo.GetOneByIdAsync(It.IsAny<Guid>())).ReturnsAsync(review);

        await _reviewService.GetOneById(It.IsAny<Guid>());

        _mockReviewRepo.Verify(repo => repo.GetOneByIdAsync(It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public async void CreateReview_ShouldInvokeRepoMethod()
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
        Product product= new Product(
            "name",
            100,
            "Description",
            5,
            0.5M,
            Guid.NewGuid()
        );
        _mockProductRepo.Setup(productRepo => productRepo.GetOneByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);
        _mockUserRepo.Setup(userRepo => userRepo.GetOneByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);
        ReviewCreateDTO reviewCreateDto = new ReviewCreateDTO() { Rating = 3, Comment = "Good product" };

        await _reviewService.CreateOne(It.IsAny<Guid>(), reviewCreateDto);

        _mockReviewRepo.Verify(repo => repo.CreateOneAsync(It.IsAny<Review>()), Times.Once);
    }

    [Fact]
    public async void DeleteReview_ShouldInvokeRepoMethod()
    {
        Review review = new Review { Rating = 3, Comment = "Good product" };
        _mockReviewRepo.Setup(repo => repo.GetOneByIdAsync(It.IsAny<Guid>())).ReturnsAsync(review);

        await _reviewService.DeleteOne(It.IsAny<Guid>());

        _mockReviewRepo.Verify(repo => repo.DeleteOneAsync(It.IsAny<Review>()), Times.Once);
    }
}