using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using tv_program.Entities;

namespace tv_program;

public class TvProgramDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public TvProgramDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<TvProgram> TvPrograms { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsHistoryTable("__EFMigrationsHistory", "TvProgram"));

        optionsBuilder.LogTo(x => Debug.WriteLine(x));
    }
}