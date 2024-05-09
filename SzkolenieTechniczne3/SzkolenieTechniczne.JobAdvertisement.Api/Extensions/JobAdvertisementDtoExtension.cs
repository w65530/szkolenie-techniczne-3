using SzkolenieTechniczne.Company.Storage.Entities;
using SzkolenieTechniczne.JobAdvertisement.CrossCutting.Dtos;

namespace SzkolenieTechniczne.JobAdvertisement.Api.Extensions
{
    public static class JobAdvertisementDtoExtension
    {
        public static SzkolenieTechniczne.JobAdvertisement.Storage.Entities.JobAdvertisement ToEntity(this JobAdvertisementDto dto)
        {
            return new SzkolenieTechniczne.JobAdvertisement.Storage.Entities.JobAdvertisement
            {
                Id = dto.Id,
              CompanyId = dto.CompanyId,
              CompanyName = dto.CompanyName,
              JobPositionExternalId = dto.JobPositionExternalId,
              JobPositionName = dto.JobPositionName,
              TargetBoth = dto.TargetBoth,
              TargetFemale = dto.TargetFemale,
              TargetMale = dto.TargetMale,
              WorkStartDate = dto.WorkStartDate,
            };
        }
    }
}

