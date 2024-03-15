namespace OrderService.Models;
public class AddItemCommand
{
    public int ProductId { get; set; }
    public Guid? SessionId { get; set; }
    public int Quantity { get; set; }
}
