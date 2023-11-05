using Microsoft.EntityFrameworkCore;
using OrderManagement.Model;

namespace OrderManagement.DBContext
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options)
        { }
        public DbSet<OrderDetail>? OrderDetail{ get; set; }
        public DbSet<VendorDetails>? VendorDetails { get; set; }

    }
}
