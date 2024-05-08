using AutoMapper;
using Moq;
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Core.src.ValueObject;
using Server.Infrastructure.src.Database;
using Server.Service.src.DTO;
using Server.Service.src.ServiceImplement;
using Server.Service.src.Shared;

namespace Server.Test.src;

public class ProductServiceTest
{
    private static IMapper _mapper;
    private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

    private readonly ProductService _productService;
    private readonly Mock<IProductRepo> _mockProductRepo = new Mock<IProductRepo>();
    private readonly Mock<ICategoryRepo> _mockCategoryRepo = new Mock<ICategoryRepo>();

    public ProductServiceTest()
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
        _productService = new ProductService(_mockProductRepo.Object, _mapper, _mockCategoryRepo.Object);
    }

    [Fact]
    public async Task GetAllProductsAsync_ShouldReturnAllProducts()
    {
        // Arrange
        var products = SeedingData.Products;
        var options = new QueryOptions { PageNo = 0, PageSize = 20, sortType = SortType.byTitle, sortOrder = SortOrder.asc };
        _mockProductRepo.Setup(x => x.GetAllAsync(options)).ReturnsAsync(products);
        _mockMapper.Setup(m => m.Map<IEnumerable<ProductReadDTO>>(products)).Returns(products.Select(p => new ProductReadDTO { Name = p.Name }));

        // Act
        var result = await _productService.GetAllProductsAsync(options);

        // Assert
        Assert.Equal(120, result.Count());
    }

    [Fact]
    public async void GetAllProductsAsync_ShouldInvokeRepoMethod()
    {
        var options = new QueryOptions { PageSize = 120, PageNo = 0, sortType = SortType.byTitle, sortOrder = SortOrder.asc };
        await _productService.GetAllProductsAsync(options);
        _mockProductRepo.Verify(repo => repo.GetAllAsync(options), Times.Once);
    }

    [Fact]
    public async void GetProductById_ShouldInvokeRepoMethod()
    {
        Product product = new Product("", 1, "", 1, 1, Guid.NewGuid());
        _mockProductRepo.Setup(repo => repo.GetOneByIdAsync(It.IsAny<Guid>())).ReturnsAsync(product);

        await _productService.GetProductById(It.IsAny<Guid>());

        _mockProductRepo.Verify(repo => repo.GetOneByIdAsync(It.IsAny<Guid>()), Times.Once);
    }

    [Fact]
    public async Task GetOneByIdAsync_ReturnsProduct_WhenValidIdProvided()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var product = new Product("Product", 100, "Product description", 1, 0.2M, productId);
        _mockProductRepo.Setup(x => x.GetOneByIdAsync(productId)).ReturnsAsync(product);
        _mockMapper.Setup(m => m.Map<ProductReadDTO>(product)).Returns(new ProductReadDTO { 
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            Inventory = product.Inventory,
            Weight = product.Weight,
        });

        // Act
        var result = await _productService.GetProductById(productId);

        // Assert
        Assert.Equal("Product", result.Name);
        Assert.Equal(100, result.Price);
        Assert.Equal("Product description", result.Description);
        Assert.Equal(1, result.Inventory);
        Assert.Equal(0.2M, result.Weight);
    }
}