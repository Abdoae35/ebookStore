public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string BookUrl { get; set; }
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }

    public ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
    public ICollection<ReviewAndRating> Reviews { get; set; } = new List<ReviewAndRating>();
}