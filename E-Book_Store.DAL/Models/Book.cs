public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string BookUrl { get; set; }
    public string Description { get; set; } = null!;
    public double Price { get; set; }
    public string ImageUrl { get; set; } = null!;

    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    
    
    //Many book to Many Cart
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
    public ICollection<ReviewAndRating> Reviews { get; set; } = new List<ReviewAndRating>();
    
    
    //many book to one wishing list 
    public int? WhishingId { get; set; } // Allow nullable f
    public WhisingList? WhisingList { get; set; } 
}