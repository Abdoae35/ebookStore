public class ReviewAndRating
{
    public int RateId { get; set; }
    public int NumStar { get; set; }
    public string? Description { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}