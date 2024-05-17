using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;
using Microsoft.AspNetCore.Mvc;
using Server.Core.src.Common;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
    [Authorize(Roles = "Admin")]
    public async Task<IEnumerable<OrderReadDTO>> GetAllOrdersAsync([FromQuery] QueryOptions options)
    {
        return await _orderService.GetAll(options);
    }
    [HttpGet("api/v1/orders/admin/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IEnumerable<OrderReadDTO>> GetAllOrdersByUserAsync([FromRoute] Guid id)
    {
        return await _orderService.GetByUser(id);
    }
    [HttpGet("api/v1/orders/{id}")]
    public async Task<OrderReadDTO> GetOrderByIdAsync([FromRoute] Guid id)
    {
        return await _orderService.GetOneById(id);
    }
    [HttpPost("api/v1/orders")]
    public async Task<OrderReadDTO> CreateOrderAsync([FromBody] OrderCreateDTO order)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return await _orderService.CreateOne(Guid.Parse(userId), order);
    }
    [HttpPatch("api/v1/orders/{id}")]
    public async Task<OrderReadDTO> UpdateOrderByIdAsync([FromRoute] Guid id, [FromBody] OrderUpdateDTO orderUpdateDto)
    {
        return await _orderService.UpdateOne(id, orderUpdateDto);
    }
    [HttpDelete("api/v1/orders/{id}")]
    public async Task<bool> DeleteOrderByIdAsync([FromRoute] Guid id)
    {
        return await _orderService.DeleteOne(id);
    }
}
