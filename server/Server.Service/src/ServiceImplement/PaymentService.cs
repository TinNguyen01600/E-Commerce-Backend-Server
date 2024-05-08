
using Server.Core.src.Common;
using Server.Core.src.Entity;
using Server.Service.src.DTO;
using Server.Service.src.ServiceAbstract;

namespace Server.Service.src.ServiceImplement;

public class PaymentService : IPaymentService
{
    private readonly IPaymentService _paymentservice;

    public PaymentService(IPaymentService paymentService)
    {
        _paymentservice = paymentService;
    }
    public Task<Payment> CreatePaymentOfOrder(Payment payment)
    {
        throw new NotImplementedException();
    }

    public Task<ReadPaymentDTO> CreatePaymentOfOrder(CreatePaymentDTO payment)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Payment>> GetAllPaymentsOfOrders(QueryOptions options)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Payment>> GetAllPaymentsOfUser(QueryOptions options)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<ReadPaymentDTO>> IPaymentService.GetAllPaymentsOfOrders(QueryOptions options)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<ReadPaymentDTO>> IPaymentService.GetAllPaymentsOfUser(QueryOptions options)
    {
        throw new NotImplementedException();
    }
}
