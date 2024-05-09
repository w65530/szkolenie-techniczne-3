using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Api.Common.Service;
using SzkolenieTechniczne.JobAdvertisement.Storage;
using SzkolenieTechniczne.JobAdvertisement.CrossCutting.Dtos;
using SzkolenieTechniczne.JobAdvertisement.Api.Extensions;
using System.Linq;

namespace SzkolenieTechniczne.JobAdvertisement.Api.Services
{
    public class JobPositionAdvertisementService : CrudServiceBase<JobPositionAdvertisementDbContext, SzkolenieTechniczne.JobAdvertisement.Storage.Entities.JobAdvertisement, JobAdvertisementDto>
    {
        private JobPositionAdvertisementDbContext _advertisementDbContext;

        public JobPositionAdvertisementService(JobPositionAdvertisementDbContext advertisementDbContext) : base(advertisementDbContext)
        {
            _advertisementDbContext = advertisementDbContext;
        }

        public async Task<JobAdvertisementDto> GetById(Guid id)
        {
            var city = await base.GetById(id);

            return city.ToDto();
        }

        public async Task<IEnumerable<JobAdvertisementDto>> Get()
        {
            var cities = await base.Get();
            return cities.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<JobAdvertisementDto>> Create(JobAdvertisementDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);
            var newDto = await GetById(entityId);

            return new CrudOperationResult<JobAdvertisementDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<JobAdvertisementDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<JobAdvertisementDto>> Update(JobAdvertisementDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
    }
}

