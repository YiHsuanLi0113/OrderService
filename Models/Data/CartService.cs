using Microsoft.EntityFrameworkCore;
using OrderService.Models;


namespace OrderService.Data;
public class CartService
{
    private readonly StoreContext dbContext;
    public CartService(StoreContext dbContext)
    {
        this.dbContext = dbContext;
    }
    //public void AddItem(AddItemCommand command)
    public AddItemResult AddItem(AddItemCommand command)
    {
        //var cart = new ShoppingCart { SessionId = Guid.NewGuid(), CreatedOn = DateTime.Now };
        ShoppingCart cart;
        if (command.SessionId.HasValue)
        {
            //cart = dbContext.ShoppingCart.SingleOrDefault(x => x.SessionId == command.SessionId);
            //using Microsoft.EntityFrameworkCore;
            cart = dbContext
                    .ShoppingCart
                    .Include(x=>x.Items)
                    .SingleOrDefault(x => x.SessionId == command.SessionId);
        }
        else
        {
            Guid newCartSessionId = Guid.NewGuid();
            cart = new ShoppingCart { SessionId = newCartSessionId, CreatedOn = DateTime.Now };
            dbContext.ShoppingCart.Add(cart);
        }




        //cart.Items.Add(new CartLineItem { ProductId = command.ProductId, Quantity = 1 });
        //dbContext.ShoppingCart.Add(cart);
        cart.Add(command.ProductId,command.Quantity);




        dbContext.SaveChanges();




         return new AddItemResult { SessionId = cart.SessionId };
    }
    public GetCartResponse Get(Guid? sessionId)
    {
        if (!sessionId.HasValue)
        {
            return new GetCartResponse();
        }


        var model = new GetCartResponse();
        var cart = dbContext
            .ShoppingCart
            .Include(x=>x.Items)
            .SingleOrDefault(x => x.SessionId == sessionId);


        foreach (var item in cart.Items)
        {
            var itemDetails = dbContext.Products.Find(item.ProductId);
            model.Items.Add(new GetCartResponse.ItemDetails {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Name = itemDetails.Name,
                Price = itemDetails.Price
            });
        }
        return model;
    }
    public void RemoveItem(RemoveItemCommand removeItemCommand)
    {
        var cart = dbContext
            .ShoppingCart
            .Include(x=>x.Items)
            .SingleOrDefault(x => x.SessionId == removeItemCommand.SessionId);
        if (cart == null)
        {
            return;
        }
        cart.Remove(removeItemCommand.ProductId);
        dbContext.SaveChanges();
    }
}
public class AddItemResult
{
    public Guid SessionId { get; set; }
}
