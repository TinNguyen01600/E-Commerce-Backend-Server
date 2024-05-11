using Server.Core.src.Entity;
using Server.Core.src.ValueObject;

namespace Server.Core.Entity;

public class Order : BaseEntity
{
    public Status Status { get; set; }
    public Guid UserId { get; set; }
    public IEnumerable<OrderProduct> OrderProducts { get; set; }

    public Order(Guid userId, Status status)
    {
        Status = status;
        UserId = userId;
    }
}
