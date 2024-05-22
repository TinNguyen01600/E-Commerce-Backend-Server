using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;
using Server.Core.src.Common;
using Server.Service.src.Shared;

namespace Server.Controller.src.Controller;

[ApiController]
[Route("api/v1/orders")]
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
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<OrderReadDTO>>> GetAllOrdersAsync([FromQuery] QueryOptions options)
    {
        return Ok(await _orderService.GetAll(options));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("user/{id}")]
    public async Task<ActionResult<IEnumerable<OrderReadDTO>>> GetAllOrdersByUserAsync([FromRoute] Guid id)
    {
        UserReadDTO foundUser = await _userService.GetOneById(id);
        if (foundUser is null)
        {
            throw CustomException.NotFoundException("User not found");
        }
        else
        {
            return Ok(await _orderService.GetByUser(id));
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<ActionResult<OrderReadDTO>> GetOrderByIdAsync([FromRoute] Guid id)
    {
        OrderReadDTO? foundOrder = await _orderService.GetOneById(id);
        if (foundOrder is null)
        {
            throw CustomException.NotFoundException("Order not found");
        }
        else
        {
            return Ok(await _orderService.GetOneById(id));
        }
    }

    [Authorize(Roles = "Customer")]
    [HttpPost()]
    public async Task<ActionResult<OrderReadDTO>> CreateOrderAsync([FromBody] OrderCreateDTO order)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return CreatedAtAction(nameof(CreateOrderAsync), await _orderService.CreateOne(Guid.Parse(userId), order));
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("{id}")]
    public async Task<ActionResult<OrderReadDTO>> UpdateOrderByIdAsync([FromRoute] Guid id, [FromBody] OrderUpdateDTO orderUpdateDto)
    {
        return Ok(await _orderService.UpdateOne(id, orderUpdateDto));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteOrderByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _orderService.DeleteOne(id));
    }

    [HttpPatch("cancel-order/{id:guid}")]
    public async Task<ActionResult<bool>> CancelOrder([FromRoute] Guid id)
    {
        OrderReadDTO? foundOrder = await _orderService.GetOneById(id);
        if (foundOrder is null)
        {
            throw CustomException.NotFoundException("Order not found");
        }
        else
        {
            return Ok(await _orderService.CancelOrder(id));
        }
    }
}
