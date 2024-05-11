using System.ComponentModel.DataAnnotations;

namespace Server.Core.src.Entity;

public class Review : BaseEntity
{
    [Range(1.0, 5.0, ErrorMessage = "Value for {0} must be between {1} and {2}")]
    public double Rating { get; set; }
    
    [MinLength(5)]
    public string Comment { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }

    public Review(double rating, string comment, Guid userId, Guid productId)
    {
        Rating = rating;
        Comment = comment;
        UserId = userId;
        ProductId = productId;
    }
}
