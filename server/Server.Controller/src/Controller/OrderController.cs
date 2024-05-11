using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;
using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;

namespace Server.Controller.src.Controller;

[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("api/v1/orders")]
    public async Task<IEnumerable<OrderReadDTO>> GetAllOrdersAsync([FromQuery] QueryOptions options)
    {
        return await _orderService.GetAllOrdersAsync(options);
    }
    [HttpGet("api/v1/orders/admin/{id}")]
    public async Task<IEnumerable<OrderReadDTO>> GetAllOrdersByUserAsync([FromQuery] QueryOptions options, [FromRoute] Guid id)
    {
        return await _orderService.GetAllOrdersByUserAsync(options);
    }
    [HttpGet("api/v1/orders/{id}")]
    public async Task<OrderReadDTO> GetOrderByIdAsync([FromRoute] Guid id)
    {
        return await _orderService.GetOrderByIdAsync(id);
    }
    [HttpPost("api/v1/orders")]
    public async Task<CreateOrderDTO> CreateOrderAsync([FromBody] CreateOrderDTO order)
    {
        return await _orderService.CreateOrderAsync(order);
    }
    [HttpPatch("api/v1/orders/{id}")]
    public async Task<UpdateOrderDTO> UpdateOrderByIdAsync([FromRoute] Guid id)
    {
        return await _orderService.UpdateOrderByIdAsync(id);
    }
    [HttpDelete("api/v1/orders/{id}")]
    public async Task<bool> DeleteOrderByIdAsync([FromRoute] Guid id)
    {
        return await _orderService.DeleteOrderByIdAsync(id);
    }
}
