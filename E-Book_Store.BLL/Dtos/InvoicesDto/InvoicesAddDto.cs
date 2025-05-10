namespace E_Book_Store.BLL.Dtos.InvoicesDto;

public class InvoicesAddDto
{
   
    public States State { get; set; }
    public int UserId { get; set; }
    public int OrderId { get; set; }
}