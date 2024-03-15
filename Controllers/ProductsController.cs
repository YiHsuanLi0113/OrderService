using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;


namespace OrderService.Controllers;
//using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepo _productrepo;
    public ProductsController(IProductRepo productrepo)
    {
            _productrepo = productrepo;
    }
// GET: products
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        if (!_productrepo.GetAllProducts().Any())
        {
            return NotFound();
        }
        var products = _productrepo.GetAllProducts();
        return Ok(products);
    }
    // GET: api/products/5
    [HttpGet("{id}")]
    public  ActionResult<IEnumerable<Product>> GetProduct(short id)
    {
        var product=_productrepo.GetProductById(id);  
        if (product == null)
        {
            return NotFound();
        }
        else {
            return Ok(product);
        }
    }
   
    // PUT: api/Products/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(short id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }
        _productrepo.UpdateProduct(product);




        try
        {
           _productrepo.SaveChanges();  
        }
        catch (DbUpdateConcurrencyException)
        {
            if (_productrepo.GetProductById(id)==null)
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }


     // POST: api/Orders
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<Product> PostProduct(Product product)
    {
        if (!_productrepo.GetAllProducts().Any())
        {
            return NotFound();
        }
        _productrepo.CreateProduct(product);
        _productrepo.SaveChanges();    
        return CreatedAtAction("GetProduct", new { id = product.Id}, product);
    }
    // DELETE: api/Orders/5
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(short id)
    {
        if (!_productrepo.GetAllProducts().Any())
        {
            return NotFound();
        }
        var product = _productrepo.GetProductById(id);  
        if (product == null)
        {
            return NotFound();
        }
        _productrepo.DeleteProduct(product);
        _productrepo.SaveChanges();
        return NoContent();
    }
}
