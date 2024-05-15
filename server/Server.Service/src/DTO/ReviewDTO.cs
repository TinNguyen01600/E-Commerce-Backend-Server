using Server.Core.src.Entity;

namespace Server.Service.src.DTO;

public class ReviewReadDTO
{
    public Guid Id { get; set; }
    public double Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public User User { get; set; }

    public void ReadReviews(Review review)
    {
        review.Id = Id;
        review.Rating = Rating;
        review.Comment = Comment;
        review.User = User;
    }
}

public class ReviewCreateDTO
{
    public double Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public Guid ProductId { get; set; }
}

public class ReviewUpdateDTO
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
