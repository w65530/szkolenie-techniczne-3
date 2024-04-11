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
    internal class CompanyConfiguration : IEntityTypeConfiguration<Entities.Company>
    {
        public void Configure(EntityTypeBuilder<Entities.Company> builder)
        {
            builder
                .HasOne(company => company.Address)
                .WithOne(address => address.Company)
                .HasForeignKey<CompanyAddress>(address => address.CompanyId);
        }
    }
}
