using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StorageEntities = SzkolenieTechniczne.Company.Storage.Entities;
using SzkolenieTechniczne.Company.Storage.Entities;
using SzkolenieTechniczne.Company.Storage.Configurations;
using SzkolenieTechniczne.Common.Storage;

namespace SzkolenieTechniczne.Company.Storage
{
    public  class CompanyDbContext : TechnicalTrainingContext
    {
        private IConfiguration _configuration { get; }

        public DbSet<StorageEntities.Company> Companies { get; set; } = null!;
        public DbSet<CompanyAddress> CompanyAddresses { get; set; } = null!;
        public DbSet<JobPosition> JobPositions { get; set; } = null!;
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryTranslation> CountryTranslations { get; set; }

        public CompanyDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server = 127.0.0.1; Database = company-dev; user id = sa; password = asdASD123; Encrypt = false; TrustServerCertificate = true; Integrated Security = false;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Company"));

            options.LogTo(x => System.Diagnostics.Debug.WriteLine(x));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new JobPositionConfiguration());
        }
    }
}
