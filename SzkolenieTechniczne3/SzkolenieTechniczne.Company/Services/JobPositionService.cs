using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SzkolenieTechniczne.Api.Common.Service;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage;
using System.Linq;
using SzkolenieTechniczne.Company.Extensions;

namespace SzkolenieTechniczne.Company.Services
{
    public class JobPositionService : CrudServiceBase<CompanyDbContext,
                    SzkolenieTechniczne.Company.Storage.Entities.JobPosition, JobPositionDto>
    {
        private CompanyDbContext _companyDbContext;

        public JobPositionService(CompanyDbContext companyDbContext) : base(companyDbContext)
        {
            _companyDbContext = companyDbContext;
        }

        public async Task<JobPositionDto> GetById(Guid id)
        {
            var jobPosition = await base.GetById(id);

            return jobPosition.ToDto();
        }

        public async Task<IEnumerable<JobPositionDto>> Get()
        {
            var jobPositions = await base.Get();
            return jobPositions.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<JobPositionDto>> Create(JobPositionDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);
            var newDto = await GetById(entityId);

            return new CrudOperationResult<JobPositionDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<JobPositionDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }

    }
}


