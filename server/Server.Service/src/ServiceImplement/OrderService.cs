using Server.Core.src;
using Server.Core.src.Common;
using Server.Core.src.RepoAbstract;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Service.src.ServiceImplement;

public class OrderService : IOrderService
{
    private readonly IOrderRepo _orderRepository;

    public OrderService(IOrderRepo orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public Task<IEnumerable<ReadOrderDTO>> GetAllOrdersAsync(QueryOptions options)
    {
        //logics here??
        throw new NotImplementedException();
    }
    public Task<IEnumerable<ReadOrderDTO>> GetAllOrdersByUserAsync(QueryOptions options)
    {
        throw new NotImplementedException();
    }
    public Task<ReadOrderDTO> GetOrderByIdAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }
    public Task<CreateOrderDTO> CreateOrderAsync(CreateOrderDTO createOrderDTO)
    {
        throw new NotImplementedException();
    }
    public Task<UpdateOrderDTO> UpdateOrderByIdAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeleteOrderByIdAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }
}
