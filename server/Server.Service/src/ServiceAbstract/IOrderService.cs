using Server.Core.Entity;
using Server.Service.src.DTO;

namespace Server.Service.src.ServiceAbstract;
public interface IOrderService : IBaseService<Order, OrderReadDTO, OrderCreateDTO, OrderUpdateDTO>
{
    Task<IEnumerable<OrderReadDTO>> GetByUser(Guid userId);
    Task<OrderReadDTO> CreateOne(Guid userId, OrderCreateDTO orderCreateDto);
    Task<bool> CancelOrder(Guid id);
}
