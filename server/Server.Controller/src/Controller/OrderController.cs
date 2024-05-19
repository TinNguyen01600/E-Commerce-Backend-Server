using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;
using Server.Core.src.Common;
using Server.Service.src.Shared;

namespace Server.Controller.src.Controller;

[ApiController]
public class OrderController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;
    private readonly IUserService _userService;
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService, IAuthorizationService authorizationService, IUserService userService)
    {
        _authorizationService = authorizationService;
        _orderService = orderService;
        _userService = userService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("api/v1/orders")]
    public async Task<IEnumerable<OrderReadDTO>> GetAllOrdersAsync([FromQuery] QueryOptions options)
    {
        return await _orderService.GetAll(options);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("api/v1/orders/user/{id}")]
    public async Task<IEnumerable<OrderReadDTO>> GetAllOrdersByUserAsync([FromRoute] Guid id)
    {
        UserReadDTO foundUser = await _userService.GetOneById(id);
        if (foundUser is null)
        {
            throw CustomException.NotFoundException("User not found");
        }
        else
        {
            return await _orderService.GetByUser(id);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("api/v1/orders/{id}")]
    public async Task<OrderReadDTO> GetOrderByIdAsync([FromRoute] Guid id)
    {
        OrderReadDTO? foundOrder = await _orderService.GetOneById(id);
        if (foundOrder is null)
        {
            throw CustomException.NotFoundException("Order not found");
        }
        else
        {
            return await _orderService.GetOneById(id);
        }
    }

    [Authorize(Roles = "Customer")]
    [HttpPost("api/v1/orders")]
    public async Task<OrderReadDTO> CreateOrderAsync([FromBody] OrderCreateDTO order)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return await _orderService.CreateOne(Guid.Parse(userId), order);
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("api/v1/orders/{id}")]
    public async Task<OrderReadDTO> UpdateOrderByIdAsync([FromRoute] Guid id, [FromBody] OrderUpdateDTO orderUpdateDto)
    {
        return await _orderService.UpdateOne(id, orderUpdateDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("api/v1/orders/{id}")]
    public async Task<bool> DeleteOrderByIdAsync([FromRoute] Guid id)
    {
        return await _orderService.DeleteOne(id);
    }

    [HttpPatch("api/v1/orders/cancel-order/{id:guid}")]
    public async Task<bool> CancelOrder([FromRoute] Guid id)
    {
        OrderReadDTO? foundOrder = await _orderService.GetOneById(id);
        if (foundOrder is null)
        {
            throw CustomException.NotFoundException("Order not found");
        }
        else
        {
            return await _orderService.CancelOrder(id);
        }
    }
}
