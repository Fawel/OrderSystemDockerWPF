using Microsoft.EntityFrameworkCore;

namespace OrderSystem.DataModels
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<OrderDb> Orders { get; set; }
        public DbSet<ItemDb> Items { get; set; }
        public DbSet<OrderItemsDb> OrderItems { get; set; }
    }
}
