using Server.Core.src.Common;
using Server.Service.src.DTO;

namespace Server.Service.src.ServiceAbstract;
public interface IOrderService
{
    public Task<IEnumerable<ReadOrderDTO>> GetAllOrdersAsync(QueryOptions options);
    public Task<IEnumerable<ReadOrderDTO>> GetAllOrdersByUserAsync(QueryOptions options);
    public Task<ReadOrderDTO> GetOrderByIdAsync(Guid orderId);
    public Task<CreateOrderDTO> CreateOrderAsync(CreateOrderDTO createOrderDTO);
    public Task<UpdateOrderDTO> UpdateOrderByIdAsync(Guid orderId);
    public Task<bool> DeleteOrderByIdAsync(Guid orderId);
}
