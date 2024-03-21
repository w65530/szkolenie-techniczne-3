using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;

namespace SzkolenieTechniczne.Geo.Extensions;

public static class CountryExtension
{
    public static CountryDto ToDto(this Country entity)
    {  
        return new CountryDto
        {
            Id = entity.Id,
            Name = new LocalizedString(entity.Translations.Select(t => new KeyValuePair<string, string>(t.LanguageCode, t.Name))),
            Alpha3Code = entity.Alpha3Code
        };
    }
}