using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Storage;

public class GeoDbContext : DbContext
{
    public GeoDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private IConfiguration _configuration { get; }

    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryTranslation> CountryTranslations { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<CityTranslation> CityTranslations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            @"server = 127.0.0.1; Database = geo-dev; user id = sa; password = asdASD123; Encrypt = false; TrustServerCertificate = true; Integrated Security = false;",
            x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Geo"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}