using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fish_Shop.Data;

public class Fish_ShopContext : IdentityDbContext<IdentityUser>
{
    public Fish_ShopContext(DbContextOptions<Fish_ShopContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
    //public DbSet<User> Users { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=comp\\LOCALSQLSERVER;Database=Fish_Shop_DB1;Trusted_Connection=True;TrustServerCertificate=True;"); //1st

        //optionsBuilder.UseSqlite("Data Source=helloapp.db");     //2nd if no service connected

        //LOGGING
        //optionsBuilder.LogTo(logstream.WriteLine, LogLevel.Trace); //possible without LogLevel.Information
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
