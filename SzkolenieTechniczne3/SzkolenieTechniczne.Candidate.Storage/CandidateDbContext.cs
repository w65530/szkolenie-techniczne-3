using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SzkolenieTechniczne.Common.Storage;
using SzkolenieTechniczne.Candidate.Storage.Entities;

namespace SzkolenieTechniczne.Candidate.Storage
{
    public class CandidateDbContext : TechnicalTrainingContext
    {
        private IConfiguration _configuration { get; }

        public DbSet<Entities.Candidate> Candidates { get; set; }
        public DbSet<CandidateAddress> CandidateAddress { get; set; }

        public CandidateDbContext(IConfiguration configuration)
          : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(@"server = 10.200.2.28; Database = geo-dev-nrAlbumu; User Id = stud; Password =wsiz; ",
            options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=candidate-dev;trusted_connection=true;",
                    //  options.UseSqlServer("",
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Geo"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
