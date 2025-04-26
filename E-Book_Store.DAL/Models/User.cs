

public class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public Role Role { get; set; }
    public DateTime DateOfCreation { get; set; } = DateTime.Now;
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<ReviewAndRating> Reviews { get; set; } = new List<ReviewAndRating>();
}