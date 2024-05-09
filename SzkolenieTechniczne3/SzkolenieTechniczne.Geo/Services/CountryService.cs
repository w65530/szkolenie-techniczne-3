using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;
using SzkolenieTechniczne.Geo.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SzkolenieTechniczne.Geo.Extensions;
using SzkolenieTechniczne.Api.Common.Service;

namespace SzkolenieTechniczne.Geo.Services
{
    public class CountryService : CrudServiceBase<GeoDbContext, Country, CountryDto>
    {
        private GeoDbContext _geoDbContext;

        public CountryService(GeoDbContext geoDbContext): base(geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }

        public async Task<CountryDto> GetById(Guid id)
        {
            var country = await base.GetById(id);

            return country.ToDto();
        }

        public async Task<IEnumerable<CountryDto>> Get()
        {
            var countries = await _geoDbContext
                .Set<Country>()
                .Include(x=>x.Translations)
                .AsNoTracking()
                .ToListAsync();
            return countries.Select(e => e.ToDto());
        }

        public async Task<CrudOperationResult<CountryDto>> Create(CountryDto dto)
        {
            var entity = dto.ToEntity();

           var entityId = await base.Create(entity);
            var newDto = await GetById(entityId);

            return new CrudOperationResult<CountryDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<CountryDto>> Delete(Guid id)
        {
           return await base.Delete(id);
        }

        public async Task<CrudOperationResult<CountryDto>> Update(CountryDto dto)
        {
            var entity = dto.ToEntity();

           return await base.Update(entity);
        }
    }
}
