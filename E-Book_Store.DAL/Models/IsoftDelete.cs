namespace E_Book_Store.DAL.Models
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}