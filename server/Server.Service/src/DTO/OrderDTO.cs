using Server.Core.Entity;
using Server.Core.src.Entity;
using Server.Core.src.ValueObject;

namespace Server.Service.src.DTO;

public class OrderReadDTO : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public Status Status { get; set; }
    public Guid UserId { get; set; }
}
public class CreateOrderDTO
{
    public Guid UserId { get; set; }
    public Status Status { get; set; }
    public CreateOrderDTO(Guid userId)
    {
        UserId = userId;
    }
}
public class UpdateOrderDTO
{
    public Status Status { get; set; }

    public UpdateOrderDTO(Status status, DateTime dateOfDelivery, Guid? addressId)
    {
        Status = status;
    }

    public Order UpdateOrder(Order oldOrder)
    {
        oldOrder.Status = Status;
        return oldOrder;
    }
}
