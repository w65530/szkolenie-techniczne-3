using System.Collections.Generic;
using System.Linq;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.JobAdvertisement.CrossCutting.Dtos;

namespace SzkolenieTechniczne.JobAdvertisement.Api.Extensions
{
    public static class JobAdvertisementExtension
    {
        public static JobAdvertisementDto ToDto(this SzkolenieTechniczne.JobAdvertisement.Storage.Entities.JobAdvertisement entity)
        {
            return new JobAdvertisementDto
            {
                Id = entity.Id,
                WorkStartDate = entity.WorkStartDate,
                TargetMale = entity.TargetMale,
                TargetFemale = entity.TargetFemale,
                TargetBoth = entity.TargetBoth,
                CompanyId = entity.CompanyId,
                CompanyName = entity.CompanyName,
                JobPositionExternalId = entity.JobPositionExternalId,
                Description = new LocalizedString(entity.Translations.Select(t =>
                new KeyValuePair<string, string>(t.LanguageCode, t.Description))),
                Name = new LocalizedString(entity.Translations.Select(t =>
                new KeyValuePair<string, string>(t.LanguageCode, t.Name))),
                JobPositionName = entity.JobPositionName,
                Responsibilities = new LocalizedString(entity.Translations.Select(t =>
                new KeyValuePair<string, string>(t.LanguageCode, t.Responsibilities))),
            };
        }
    }
}

