using AutoMapper;
using Moq;
using Server.Core.Entity;
using Server.Core.src.Common;
using Server.Core.src.RepoAbstract;
using Server.Core.src.ValueObject;
using Server.Service.src.ServiceImplement;
using Server.Service.src.Shared;

namespace Server.Test.src;

public class OrderServiceTest
{
    private static IMapper _mapper;
    private readonly OrderService _orderService;
    private readonly Mock<IOrderRepo> _mockOrderRepo = new Mock<IOrderRepo>();
    private readonly Mock<IProductRepo> _mockProductRepo = new Mock<IProductRepo>();
    private readonly Mock<IUserRepo> _mockUserRepo = new Mock<IUserRepo>();
    public OrderServiceTest()
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
        _orderService = new OrderService(_mockOrderRepo.Object, _mapper, _mockUserRepo.Object, _mockProductRepo.Object);
    }

    [Fact]
    public async void GetAllOrdersAsync_ShouldInvokeRepoMethod()
    {
        var options = new QueryOptions { PageSize = 120, PageNo = 0, sortType = SortType.byTitle, sortOrder = SortOrder.asc };
        await _orderService.GetAll(options);
        _mockOrderRepo.Verify(repo => repo.GetAllAsync(options), Times.Once);
    }

    [Fact]
    public async void GetOrderByIdAsync_ShouldInvokeRepoMethod()
    {
        Order order = new Order() { };
        _mockOrderRepo.Setup(repo => repo.GetOneByIdAsync(It.IsAny<Guid>())).ReturnsAsync(order);

        await _orderService.GetOneById(It.IsAny<Guid>());

        _mockOrderRepo.Verify(repo => repo.GetOneByIdAsync(It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public async void DeleteOrderAsync_ShouldInvokeRepoMethod()
    {
        Order order = new Order() { };
        _mockOrderRepo.Setup(repo => repo.GetOneByIdAsync(It.IsAny<Guid>())).ReturnsAsync(order);

        var result = await _orderService.DeleteOne(It.IsAny<Guid>());

        _mockOrderRepo.Verify(repo => repo.DeleteOneAsync(It.IsAny<Order>()), Times.Once);
        Assert.True(result);
    }
}