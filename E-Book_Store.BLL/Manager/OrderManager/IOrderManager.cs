namespace E_Book_Store.BLL.Manager.OrderManager;

public interface IOrderManager
{
    public IEnumerable<OrderReadDto> GetAll();
    public OrderReadDto GetById(int id);
    public void insert(OrderAddDto orderAddDto);
    public void Update(OrderUpdateDto orderUpdateDto);
    public void Delete(int id);
}