using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Storage.Configurations
{
    internal class JobPositionConfiguration : IEntityTypeConfiguration<JobPosition>
    {
        public void Configure(EntityTypeBuilder<JobPosition> builder)
        {

            builder
                .HasOne(jobPosition => jobPosition.Company)
                .WithMany(company => company.JobPositions)
                .HasForeignKey(jobPosition => jobPosition.CompanyId);

        }
    }
}
