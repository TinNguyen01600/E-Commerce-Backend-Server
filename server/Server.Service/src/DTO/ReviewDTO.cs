using Server.Core.src.Entity;

namespace Server.Service.src.DTO;

public class ReadReviewDTO
{
    public Guid Id { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public DateTime ReviewDate { get; set; }

    public void ReadReviews(Review review)
    {
        review.Id = Id;
        review.Rating = Rating;
        review.Comment = Comment;
        review.UserId = UserId;
        review.ReviewDate = ReviewDate;
    }
}

public class CreateReviewDTO
{
    public double Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime ReviewDate { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public Review CreateReviews()
    {
        return new Review(Rating, Comment, UserId, ProductId, ReviewDate);
    }
}

public class UpdateReviewsDTO
{
    public double Rating { get; set; }
    public string Comment { get; set; } = string.Empty;

    public Review UpdateReview(Review oldreview)
    {
        if (oldreview.Rating != 0.0 && String.IsNullOrEmpty(oldreview.Comment))
        {
            oldreview.Rating = Rating;
            oldreview.Comment = Comment;
        }

        return oldreview;
    }
}
