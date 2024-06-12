using Microsoft.EntityFrameworkCore;
using przykladowy_1_client.Entities;

namespace przykladowy_1_client;

public class ClientServiceDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    
    public DbSet<Client> Clients { get; set; } = null!;
    
    public DbSet<CarService> CarServices { get; set; } = null!;
    
    public ClientServiceDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), 
            x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Client"));
        
        optionsBuilder.LogTo(x => System.Diagnostics.Debug.WriteLine(x));
    }
}