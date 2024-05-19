using Server.Core.Entity;
using Server.Core.src.Entity;
using Server.Core.src.ValueObject;

namespace Server.Service.src.DTO;

public class OrderReadDTO : BaseEntity
{
    public UserReadDTO User { get; set; }
    public IEnumerable<OrderProductReadDTO> OrderProducts { get; set; }
    public Status Status { get; set; }
}
public class OrderCreateDTO
{
    public IEnumerable<OrderProductCreateDTO> OrderProducts { get; set; }
    public Status Status { get; set; } = Status.pending;
}
public class OrderUpdateDTO
{
    public Status Status { get; set; } = Status.pending;
}
