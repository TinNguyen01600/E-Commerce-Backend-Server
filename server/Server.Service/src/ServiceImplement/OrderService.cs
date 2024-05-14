using AutoMapper;
using Server.Core.Entity;
using Server.Core.src.Common;
using Server.Core.src.RepoAbstract;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

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

    public Task<bool> CancelOrder(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderReadDTO> CreateOne(Guid userId, OrderCreateDTO orderCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderReadDTO>> GetByUser(Guid userId)
    {
        throw new NotImplementedException();
    }
}
