using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using tv_show.Entities;

namespace tv_show;

public class TvShowDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public TvShowDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<TvShow> TvShows { get; set; } = null!;
    public DbSet<TvProgram> TvPrograms { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsHistoryTable("__EFMigrationsHistory", "TvShow"));

        optionsBuilder.LogTo(x => Debug.WriteLine(x));
    }
}