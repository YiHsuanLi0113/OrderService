using Microsoft.EntityFrameworkCore;
using OrderService.Models;


namespace OrderService.Data;
public class CheckoutService
{
    private readonly StoreContext dbContext;
    public CheckoutService(StoreContext storeContext)
    {
        this.dbContext = storeContext;
    }
    public void PlaceOrder(CheckoutCommand command)
    {
        // 1.create an order
        var order = Order.FromCheckout(command);
        // 2.get cart for Session
        // for each item in cart, add to order
        var cart = dbContext
            .ShoppingCart
            .Include(x => x.Items)
            .SingleOrDefault(x => x.SessionId == command.SessionId);
        foreach (var item in cart.Items)
        {
            var product = dbContext.Products.SingleOrDefault(x => x.Id == item.ProductId);
            order.AddItem(product, item.Quantity);
        }
         // 3.Add Order to DB
        dbContext.Orders.Add(order);
        cart.Empty();
        dbContext.SaveChanges();
    }
}
