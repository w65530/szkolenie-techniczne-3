using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.Storage;
using SzkolenieTechniczne.JobAdvertisement.Storage.Entities;

namespace SzkolenieTechniczne.JobAdvertisement.Storage
{
    public class JobPositionAdvertisementDbContext : TechnicalTrainingContext
    {
        private IConfiguration _configuration { get; }

        public DbSet<SzkolenieTechniczne.JobAdvertisement.Storage.Entities.JobAdvertisement> JobAdvertisements { get; set; }
        public DbSet<JobAdvertisementTranslation> JobAdvertisementTranslations { get; set; }

        public JobPositionAdvertisementDbContext(IConfiguration configuration)
          : base()
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer(@"server = 10.200.2.28; Database = geo-dev-nrAlbumu; User Id = stud; Password =wsiz; ",
            options.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=jobAdvertisement-dev;trusted_connection=true;",
                    //  options.UseSqlServer("",
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "JobAdvertisement"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
