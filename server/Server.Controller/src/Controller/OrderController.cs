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
        UserReadDTO foundUser = await _userService.GetOneById(id);
        if (foundUser is null)
        {
            throw CustomException.NotFoundException("User not found");
        }
        else
        {
            var authorizationResult = _authorizationService
           .AuthorizeAsync(HttpContext.User, foundUser, "AdminOrOwnerAccount")
           .GetAwaiter()
           .GetResult();

            if (authorizationResult.Succeeded)
            {
                return await _orderService.GetByUser(id);
            }
            else if (User.Identity!.IsAuthenticated)
            {
                throw CustomException.UnauthorizedException("Not authenticated");
            }
            else
            {
                throw CustomException.UnauthorizedException("Not authorized");
            }
        }
    }
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
            var authorizationResult = _authorizationService.AuthorizeAsync(HttpContext.User, foundOrder, "AdminOrOwnerOrder")
                .GetAwaiter()
                .GetResult();

            if (authorizationResult.Succeeded)
            {
                return await _orderService.GetOneById(id);
            }
            else if (User.Identity!.IsAuthenticated)
            {
                throw CustomException.UnauthorizedException("Not authenticated");
            }
            else
            {
                throw CustomException.UnauthorizedException("Not authorized");
            }
        }
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
            var authorizationResult = _authorizationService
           .AuthorizeAsync(HttpContext.User, foundOrder, "AdminOrOwnerOrder")
           .GetAwaiter()
           .GetResult();

            if (authorizationResult.Succeeded)
            {
                return await _orderService.CancelOrder(id);
            }
            else if (User.Identity!.IsAuthenticated)
            {
                throw CustomException.UnauthorizedException("Not authenticated");
            }
            else
            {
                throw CustomException.UnauthorizedException("Not authorized");
            }
        }
    }
}
