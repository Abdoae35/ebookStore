namespace EbookFrontEnd.ViewModels.BooksVm;

public class BookResponseVm
{
    public List<BookReadVM> Data { get; set; }
    public int CurrentPage { get; set; }
    
    //Pagination data got from api 
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
    public int totalItems { get; set; }
    
    public int TotalCount { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string BookUrl { get; set; }
    public string ImageUrl { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;
   
}