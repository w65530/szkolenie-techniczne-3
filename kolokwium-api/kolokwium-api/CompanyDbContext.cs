using kolokwium_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_api;

public class CompanyDbContext : DbContext
{
    private IConfiguration Configuration { get; }
    
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<CompanyAddress> CompanyAddresses { get; set; } = null!;
    
    public CompanyDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsHistoryTable("Migrations", "Company" ));
        
        optionsBuilder.LogTo(x => System.Diagnostics.Debug.WriteLine(x));
    }
}