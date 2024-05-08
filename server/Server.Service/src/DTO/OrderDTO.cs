using Server.Core.Entity;
using Server.Core.src.ValueObject;

namespace Server.Service.src.DTO;

public class ReadOrderDTO
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Status Status { get; set; }
    public Guid UserId { get; set; }
    public DateTime DateOfDelivery { get; set; }
    public void ReadOrder(Order order)
    {
        Id = order.Id;
        OrderDate = order.OrderDate;
        Status = order.Status;
        UserId = order.UserId;
        DateOfDelivery = order.DateOfDelivery;
    }
}
public class CreateOrderDTO
{
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
    public CreateOrderDTO(Guid userId, Guid addressId)
    {
        UserId = userId;
        AddressId = addressId;
    }

    public Order CreateOrder()
    {
        return new Order(UserId, AddressId);
    }
}
public class UpdateOrderDTO
{
    public Status Status { get; set; }
    public DateTime DateOfDelivery { get; set; }
    public Guid? AddressId { get; set; }

    public UpdateOrderDTO(Status status, DateTime dateOfDelivery, Guid? addressId)
    {
        Status = status;
        DateOfDelivery = dateOfDelivery;
        AddressId = addressId;
    }

    public Order UpdateOrder(Order oldOrder)
    {
        oldOrder.Status = Status;
        oldOrder.DateOfDelivery = DateOfDelivery;
        if (AddressId is not null) oldOrder.AddressId = (Guid)AddressId;
        return oldOrder;
    }
}
