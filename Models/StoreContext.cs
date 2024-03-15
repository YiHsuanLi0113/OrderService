using Microsoft.EntityFrameworkCore;


namespace OrderService.Models;
public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) {
    }
    public  virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name= "iPhone",
                Description="Apple iPhone 15 ",
                Price= 30000
            },
            new Product
            {
                Id = 2,
                Name= "iMac",
                Description="Apple iMac 2024 ",
                Price= 50000
            },
            new Product
            {
                Id = 3,
                Name= "iPad",
                Description="Apple iPad  AIR 2024 ",
                Price= 20000
            }
        );
    }
}
