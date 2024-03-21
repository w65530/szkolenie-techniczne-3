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
        options.UseSqlServer(@"server = 10.200.2.28; Database = geo-dev-w65530; User Id = stud; ",
            x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Geo"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}