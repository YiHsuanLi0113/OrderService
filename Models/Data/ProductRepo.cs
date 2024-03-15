using OrderService.Models;


namespace OrderService.Data;
public class ProductRepo:IProductRepo
{
    private readonly StoreContext _context;
    public ProductRepo(StoreContext context)
    {
        _context = context;
    }
    public void CreateProduct(Product product)
    {
        _context.Products.Add(product);
    }
    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
    }
    public void DeleteProduct(Product product)
    {
       var delproduct=_context.Products.Find(product.Id);
       _context.Products.Remove(delproduct);
    }
    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }
    public Product GetProductById(int id)
    {
         return _context.Products.FirstOrDefault(p => p.Id == id);
    }
}
