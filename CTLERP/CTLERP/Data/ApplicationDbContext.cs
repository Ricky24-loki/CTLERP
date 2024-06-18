using CTLERP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CTLERP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerType> PartnerTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItems { get; set;}
        public DbSet<Employee> Employees { get; set; }
    }
}
