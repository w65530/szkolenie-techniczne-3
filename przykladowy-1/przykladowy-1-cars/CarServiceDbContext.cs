using Microsoft.EntityFrameworkCore;
using przykladowy_1_cars.Entities;

namespace przykladowy_1_cars;

public class CarServiceDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<CarService> CarServices { get; set; } = null!;

    public CarServiceDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), 
            x => x.MigrationsHistoryTable("__EFMigrationsHistory", "CarService"));
        
        optionsBuilder.LogTo(x => System.Diagnostics.Debug.WriteLine(x));
    }
}