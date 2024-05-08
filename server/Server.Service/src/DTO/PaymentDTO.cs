using Server.Core.src.Entity;
using Server.Core.src.ValueObject;

namespace Server.Service.src.DTO;
public class ReadPaymentDTO
{
    public Guid OrderId { get; set; }
    public PaymentMethod PayMethod { get; set; }

    public void ReadPayment(Payment payment)
    {
        OrderId = payment.OrderId;
        PayMethod = payment.PayMethod;
    }
}

public class CreatePaymentDTO
{
    public Guid OrderId { get; set; }
    public PaymentMethod PayMethod { get; set; }

    public Payment CreatePayment(Payment payment)
    {
        return new Payment(payment.OrderId, payment.PayMethod);
    }
}