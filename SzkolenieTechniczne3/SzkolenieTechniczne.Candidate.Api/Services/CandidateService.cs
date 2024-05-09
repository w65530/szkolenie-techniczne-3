using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolenieTechniczne.Api.Common.Service;
using SzkolenieTechniczne.Candidate.Api.Extensions;
using SzkolenieTechniczne.Candidate.CrossCutting.Dtos;
using SzkolenieTechniczne.Candidate.Storage;
using SzkolenieTechniczne.Candidate.Storage.Entities;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using Entities = SzkolenieTechniczne.Candidate.Storage.Entities;
namespace SzkolenieTechniczne.Candidate.Api.Services
{
    public class CandidateService : CrudServiceBase<CandidateDbContext, Entities.Candidate, CandidateDto>
    {
        private CandidateDbContext _candidateDbContext;

        public CandidateService(CandidateDbContext candidateDbContext) : base(candidateDbContext)
        {
            _candidateDbContext = candidateDbContext;
        }

        public async Task<CandidateDto> GetById(Guid id)
        {
            var candidate = await base.GetById(id);

            return candidate.ToDto();
        }

        public async Task<IEnumerable<CandidateDto>> Get()
        {
            var candidates = await base.Get();
            return candidates.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<CandidateDto>> Create(CandidateDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);
            var newDto = await GetById(entityId);

            return new CrudOperationResult<CandidateDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<CandidateDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<CandidateDto>> Update(CandidateDto dto)
        {
            var entity = dto.ToEntity();

            return await base.Update(entity);
        }
    }
}
