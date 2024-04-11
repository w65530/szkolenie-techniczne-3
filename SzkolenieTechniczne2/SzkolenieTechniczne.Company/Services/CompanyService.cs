using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Extensions;
using SzkolenieTechniczne.Company.Storage;

namespace SzkolenieTechniczne.Company.Services
{
    public class CompanyService
    {
        private CompanyDbContext _companyDbContext;
        
        public CompanyService(CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }
        
        public async Task<CompanyDto> GetById(Guid id)
        {
            var company = await _companyDbContext
                .Set<Storage.Entities.Company>()
                .AsNoTracking()
                .Where(e => e.Id!.Equals(id))
                .SingleOrDefaultAsync();
            
            return company.ToDto();
        }
        
        public async Task<IEnumerable<CompanyDto>> Get()
        {
            var companies = await _companyDbContext
                .Set<Storage.Entities.Company>()
                .AsNoTracking()
                .Select(e => e.ToDto())
                .ToListAsync();
            
            return companies;
        }
        
        public async Task<CrudOperationResult<CompanyDto>> Create(CompanyDto dto)
        {
            var entity = dto.ToEntity();
            
            _companyDbContext
                .Set<Storage.Entities.Company>()
                .Add(entity);
            
            await _companyDbContext.SaveChangesAsync();
            
            var newDto = await GetById(entity.Id);
            
            return new CrudOperationResult<CompanyDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
    }
}