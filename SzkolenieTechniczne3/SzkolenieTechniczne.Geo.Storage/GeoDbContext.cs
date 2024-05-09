using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SzkolenieTechniczne.Common.Storage;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Storage
{
    public class GeoDbContext : TechnicalTrainingContext
    {
        private IConfiguration _configuration { get; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryTranslation> CountryTranslations { get; set; } 
        public DbSet<City> Cities { get; set; }
        public DbSet<CityTranslation> CityTranslations { get; set; }

        public GeoDbContext(IConfiguration configuration)
          : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(@"server = 10.200.2.28; Database = geo-dev-nrAlbumu; User Id = stud; Password =wsiz; ",
            options.UseSqlServer(@"server = 127.0.0.1; Database = geo-dev; user id = sa; password = asdASD123; Encrypt = false; TrustServerCertificate = true; Integrated Security = false;",
          //  options.UseSqlServer("",
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Geo"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
