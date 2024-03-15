namespace OrderService.Models;
public class RemoveItemCommand
{
    public Guid SessionId { get; set; }
    public int ProductId { get; set; }
}
