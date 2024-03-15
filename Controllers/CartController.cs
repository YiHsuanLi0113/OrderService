using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.Models;


namespace OrderService.Controllers;
//using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly CartService cartService;
    public CartController(CartService cartService)
    {
        this.cartService = cartService;
    }


    [HttpPost]
    public IActionResult AddItem(AddItemCommand command)
    {
        var result = cartService.AddItem(command);
        return Ok(result);
    }


    [HttpGet]
    public IActionResult Get(Guid? sessionId)
    {
        var result = cartService.Get(sessionId);
        return Ok(result);
    }
   
    [HttpDelete("{sessionId}/lines/{productId}")]
    public IActionResult RemoveItem([FromRoute]RemoveItemCommand command)
    {
        cartService.RemoveItem(command);
        return Ok();
    }
}