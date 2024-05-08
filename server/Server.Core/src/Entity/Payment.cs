using Server.Core.src.ValueObject;

namespace Server.Core.src.Entity;

public class Payment
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public PaymentMethod PayMethod { get; set; }

    public Payment(Guid orderId, PaymentMethod method)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        PayMethod = method;
    }
}
