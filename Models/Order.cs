using System.ComponentModel.DataAnnotations.Schema;


namespace OrderService.Models;
public class Order
{
    public int Id { get; set; }
    public string CustomerEmail { get; private set; }
    public List<OrderLine> Lines { get; private set; }




    internal static Order FromCheckout(CheckoutCommand command)
    {
        return new Order
        {
            CustomerEmail = command.Customer.Email,
            Lines = new List<OrderLine>()
            // other properties mapped here, as needed to stamp on the order
        };
    }
    internal void AddItem(Product product, int quantity)
    {
        Lines.Add(new OrderLine {
            Description = product.Description,
            Price = product.Price,
            ProductId = product.Id,
            Quantity = quantity
        });
    }
    public decimal GetTotal()
    {
        return Lines.Sum(x => x.Quantity * x.Price);
    }
}


public class OrderLine
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Description { get; set; }
    [Column(TypeName = "money")]
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}


