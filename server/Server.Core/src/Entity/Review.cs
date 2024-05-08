namespace Server.Core.src.Entity;

public class Review
{
    public Guid Id { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public DateTime ReviewDate { get; set; }
    public Guid OrderedProductId { get; set; }

    public Review(double rating, string comment, Guid userId, DateTime reviewDate, Guid orderedProductId)
    {
        Id = Guid.NewGuid();
        Rating = rating;
        Comment = comment;
        UserId = userId;
        ReviewDate = reviewDate;
        OrderedProductId = orderedProductId;
    }

}
