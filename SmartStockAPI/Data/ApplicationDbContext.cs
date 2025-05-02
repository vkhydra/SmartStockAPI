using Microsoft.EntityFrameworkCore;

namespace SmartStockAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ProductModel> Products { get; set; }
}