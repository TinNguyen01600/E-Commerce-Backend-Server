using Server.Core.Entity;
using Server.Core.src.Common;

namespace Server.Core.src.RepoAbstract;

public interface IOrderRepo
{
    public Task<List<Order>> GetAllOrdersAsync(QueryOptions options);
    public Task<List<Order>> GetAllOrdersByUserAsync(QueryOptions options);
    public Task<Order> GetOrderByIdAsync(Guid orderId);
    public Task<Order> CreateOrderAsync(Order order);
    public Task<Order> UpdateOrderByIdAsync(Guid orderId);
    public Task<bool> DeleteOrderByIdAsync(Guid orderId);
}
