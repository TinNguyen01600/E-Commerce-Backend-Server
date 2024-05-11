namespace Server.Core.src.Entity;

public class Review : BaseEntity
{
    public double Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public DateTime ReviewDate { get; set; }
    public Guid ProductId { get; set; }

    public Review(double rating, string comment, Guid userId, Guid productId, DateTime reviewDate)
    {
        Rating = rating;
        Comment = comment;
        UserId = userId;
        ProductId = productId;
        ReviewDate = reviewDate;
    }
}
