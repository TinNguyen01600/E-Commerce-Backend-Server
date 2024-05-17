using AutoMapper;
using Server.Core.Entity;
using Server.Core.src.Entity;
using Server.Core.src.RepoAbstract;
using Server.Core.src.ValueObject;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;
using Server.Service.src.Shared;

namespace Server.Service.src.ServiceImplement;

public class OrderService : BaseService<Order, OrderReadDTO, OrderCreateDTO, OrderUpdateDTO, IOrderRepo>, IOrderService
{
    private IUserRepo _userRepo;
    private IProductRepo _productRepo;

    public OrderService(IOrderRepo orderRepo, IMapper mapper, IUserRepo userRepo, IProductRepo productRepo) : base(orderRepo, mapper)
    {
        _userRepo = userRepo;
        _productRepo = productRepo;
    }

    public async Task<bool> CancelOrder(Guid id)
    {
        var foundOrder = await _repo.GetOneByIdAsync(id);
        DateTime currentDate = DateTime.Now;
        if (foundOrder is null)
        {
            return false;
        }
        else
        {
            TimeSpan timeDifference = currentDate - foundOrder.CreatedAt;
            if (timeDifference <= TimeSpan.FromHours(24))
            {
                foundOrder.Status = Status.cancelled;
                await _repo.UpdateOneAsync(foundOrder);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public async Task<OrderReadDTO> CreateOne(Guid userId, OrderCreateDTO orderCreateDto)
    {
        var foundUser = _userRepo.GetOneByIdAsync(userId);
        if (foundUser is null)
        {
            throw CustomException.NotFoundException("User not found");
        }
        else
        {
            var order = _mapper.Map<Order>(orderCreateDto);
            order.User = await foundUser;
            var newOrderProductList = new List<OrderProduct>();
            foreach (var orderProductDto in orderCreateDto.OrderProducts)
            {
                var foundProduct = _productRepo.GetOneByIdAsync(orderProductDto.ProductId);
                if (foundProduct == null)
                {
                    throw CustomException.NotFoundException("Product not found");
                }
                newOrderProductList.Add(new OrderProduct
                {
                    Product = await foundProduct,
                    Quantity = orderProductDto.Quantity,
                });
            }
            order.OrderProducts = newOrderProductList;
            var createdOrder = await _repo.CreateOneAsync(order);
            return _mapper.Map<OrderReadDTO>(createdOrder);
        }
    }

    public async Task<IEnumerable<OrderReadDTO>> GetByUser(Guid userId)
    {
        var foundUser = _userRepo.GetOneByIdAsync(userId);
        if (foundUser is not null)
        {
            var result = await _repo.GetByUser(userId);
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderReadDTO>>(result);
        }
        else
        {
            throw CustomException.NotFoundException("User not found");
        }
    }
}
