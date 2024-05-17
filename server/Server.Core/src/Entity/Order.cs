using Server.Core.src.Entity;
using Server.Core.src.ValueObject;

namespace Server.Core.Entity;

public class Order : BaseEntity
{
    public Status Status { get; set; }
    public User User { get; set; }
    public IEnumerable<OrderProduct> OrderProducts { get; set; }
}
