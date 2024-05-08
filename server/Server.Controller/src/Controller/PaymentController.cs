using Server.Core.src.Common;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controller.src.Controller;

[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet("/api/v1/payments")]
    public async Task<IEnumerable<ReadPaymentDTO>> GetAllPaymentsOfOrders([FromQuery] QueryOptions options)
    {
        return await _paymentService.GetAllPaymentsOfOrders(options);
    }

    [HttpPost("/api/v1/payment")]
    public async Task<ReadPaymentDTO> CreatePaymentOfOrder([FromBody] CreatePaymentDTO payment)
    {
        return await _paymentService.CreatePaymentOfOrder(payment);
    }
}
