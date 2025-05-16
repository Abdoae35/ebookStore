namespace E_Book_Store.BLL.Dtos.InvoicesDto;

public class InvoicesModifyDto
{
    public int InvoicesId { get; set; }
    public States State { get; set; }
    public int UserId { get; set; }
    public int OrderId { get; set; }
}