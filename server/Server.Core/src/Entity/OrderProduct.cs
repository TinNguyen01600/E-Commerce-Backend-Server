namespace Server.Core.src.Entity;

public class OrderProduct : BaseEntity
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}