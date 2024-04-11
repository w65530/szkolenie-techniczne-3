using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Extensions;
using SzkolenieTechniczne.Company.Storage;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Services
{
    public class JobPositionService
    {
        private CompanyDbContext _companyDbContext;
        
        public JobPositionService(CompanyDbContext companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }
        
        public async Task<JobPositionDto> GetById(Guid id)
        {
            var jobPosition = await _companyDbContext
                .Set<JobPosition>()
                .AsNoTracking()
                .Where(e => e.Id!.Equals(id))
                .SingleOrDefaultAsync();
            
            return jobPosition.ToDto();
        }
        
        public async Task<IEnumerable<JobPositionDto>> Get()
        {
            var jobPositions = await _companyDbContext
                .Set<JobPosition>()
                .AsNoTracking()
                .Select(e => e.ToDto())
                .ToListAsync();
            
            return jobPositions;
        }
        
        public async Task<CrudOperationResult<JobPositionDto>> Create(JobPositionDto dto)
        {
            var entity = dto.ToEntity();
            
            _companyDbContext
                .Set<JobPosition>()
                .Add(entity);
            
            await _companyDbContext.SaveChangesAsync();
            
            var newDto = await GetById(entity.Id);
            
            return new CrudOperationResult<JobPositionDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
    }
}