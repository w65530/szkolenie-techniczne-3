using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Api.Common.Service;
using SzkolenieTechniczne.Company.Storage;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using System.Linq;
using SzkolenieTechniczne.Company.Extensions;
using SzkolenieTechniczne.Company.Resolvers;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Services
{
    public class CompanyService : CrudServiceBase<CompanyDbContext, 
                    SzkolenieTechniczne.Company.Storage.Entities.Company, CompanyDto>
    {
        private readonly CountryIntegrationDataResolver _countryResolver;
        private CompanyDbContext _companyDbContext;

        public CompanyService(CompanyDbContext companyDbContext, CountryIntegrationDataResolver countryResolver) : base(companyDbContext)
        {
            _companyDbContext = companyDbContext;
            _countryResolver = countryResolver;
        }

        public async Task<CompanyDto> GetById(Guid id)
        {
            var company = await base.GetById(id);

            return company.ToDto();
        }

        public async Task<IEnumerable<CompanyDto>> Get()
        {
            var companies = await base.Get();
            return companies.Select(e => e.ToDto());
        }

        protected override async Task OnBeforeRecordCreatedAsync(CompanyDbContext dbContext, SzkolenieTechniczne.Company.Storage.Entities.Company entity)
        {
            if (entity.Address != null)
            {
               await _countryResolver.ResolveFor(entity.Address.CountryId);
            }
        }

            public async Task<CrudOperationResult<CompanyDto>> Create(CompanyDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);
            var newDto = await GetById(entityId);

            return new CrudOperationResult<CompanyDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<CompanyDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<CompanyDto>> Update(CompanyDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
    }
}

