using Challenge.Domain;
using Microsoft.EntityFrameworkCore;


namespace Challenge.DataAccessLayer
{
    public class OrderManagementContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public OrderManagementContext()
        {
        }

        public OrderManagementContext(DbContextOptions<OrderManagementContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OrderManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
