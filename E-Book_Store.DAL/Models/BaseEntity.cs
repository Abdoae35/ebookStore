namespace E_Book_Store.DAL.Models;

public abstract class BaseEntity
{
   public DateTime CreatedAt { get; set; }
   public DateTime UpdatedAt { get; set; }
   public virtual bool IsDeleted { get; set; }
   public DateTime DeletedAt { get; set; }
   public string DeletedBy { get; set; }
   public string CreatedBy { get; set; }
   public string UpdatedBy { get; set; }

}