using Microsoft.EntityFrameworkCore;

namespace Data.Model
{
    public class AdminShopMobileDbContext :DbContext
    {
        public AdminShopMobileDbContext(DbContextOptions<AdminShopMobileDbContext> options)
            :base(options) { }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductProducer> ProductProducer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Client> Client { get; set; }
    }
}
