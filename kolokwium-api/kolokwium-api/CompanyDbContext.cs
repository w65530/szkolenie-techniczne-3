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
        
        optionsBuilder.UseSqlServer(@"server = 127.0.0.1; Database = company-kolokwium; user id = sa; password = asdASD123; Encrypt = false; TrustServerCertificate = true; Integrated Security = false;",
            x => x.MigrationsHistoryTable("Migrations", "Company" ));
        
        optionsBuilder.LogTo(x => System.Diagnostics.Debug.WriteLine(x));
    }
}