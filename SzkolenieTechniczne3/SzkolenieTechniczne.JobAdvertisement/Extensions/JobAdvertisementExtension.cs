using System.Collections.Generic;
using System.Linq;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.JobAdvertisement.CrossCutting.Dtos;

namespace SzkolenieTechniczne.JobAdvertisement.Extensions
{
    public static class JobAdvertisementExtension
    {
        public static JobAdvertisementDto ToDto(this SzkolenieTechniczne.JobAdvertisement.Storage.Entities.JobAdvertisement entity)
        {
            return new JobAdvertisementDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                CompanyName = entity.CompanyName,
                JobPositionExternalId = entity.JobPositionExternalId,
                JobPositionName = entity.JobPositionName,
                TargetBoth = entity.TargetBoth,
                TargetFemale = entity.TargetFemale,
                TargetMale = entity.TargetMale,
                WorkStartDate = entity.WorkStartDate,
                
                Name = new LocalizedString(entity.Translations.Select(t =>
                new KeyValuePair<string, string>(t.LanguageCode, t.Name))),

                Description = new LocalizedString(entity.Translations.Select(t =>
                new KeyValuePair<string, string>(t.LanguageCode, t.Description))),

                Responsibilities = new LocalizedString(entity.Translations.Select(t =>
             new KeyValuePair<string, string>(t.LanguageCode, t.Responsibilities))),
            };
        }
    }
}
