using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.Models;


namespace OrderService.Controllers;
//using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class CheckoutController : ControllerBase
{
    //using TimeToBuy.Data;
    private readonly CheckoutService service;
    public CheckoutController(CheckoutService service)
    {
        this.service = service;
    }
    [HttpPost]
    public IActionResult Checkout(CheckoutCommand command)
    {
        service.PlaceOrder(command);
       
        return Ok();
    }
}
