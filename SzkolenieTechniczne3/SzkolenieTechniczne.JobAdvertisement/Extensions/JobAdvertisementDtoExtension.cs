using SzkolenieTechniczne.JobAdvertisement.CrossCutting.Dtos;

namespace SzkolenieTechniczne.JobAdvertisement.Extensions
{
    public static class JobAdvertisementDtoExtension
    {
        public static SzkolenieTechniczne.JobAdvertisement.Storage.Entities.JobAdvertisement ToEntity(this JobAdvertisementDto dto)
        {
            return new SzkolenieTechniczne.JobAdvertisement.Storage.Entities.JobAdvertisement
            {
                Id = dto.Id,
                WorkStartDate = dto.WorkStartDate,
                CompanyId = dto.CompanyId,
                CompanyName = dto.CompanyName,
                TargetMale = dto.TargetMale,
                TargetFemale = dto.TargetFemale,
                TargetBoth = dto.TargetBoth,
                JobPositionExternalId = dto.JobPositionExternalId,
                JobPositionName = dto.JobPositionName,
            };

        }
    }

    
}
