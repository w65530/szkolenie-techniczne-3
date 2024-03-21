﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Storage;

public class GeoDbContext : DbContext
{
    private IConfiguration Configuration { get; }
    
    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryTranslation> CountryTranslations { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<CityTranslation> CityTranslations { get; set; }
    
    public GeoDbContext(IConfiguration configuration) : base()
    {
        _configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(@"server=(localdb)MSSQLLocalDB;database=geo-dev;trusted_connection=true;", x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Geo"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}