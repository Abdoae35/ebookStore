namespace E_Book_Store.BLL.Dtos.ReviewAndRatingDtos;

public class ReviewAndRatingAddDto
{
    
    public int NumStar { get; set; }
    public string? Description { get; set; }
    public int BookId { get; set; }
    public int UserId { get; set; }
   
}