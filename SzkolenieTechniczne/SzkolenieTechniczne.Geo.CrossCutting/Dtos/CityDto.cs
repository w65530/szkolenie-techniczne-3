using System.ComponentModel.DataAnnotations;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Common.CrossCutting.ValidationAttributes;

namespace SzkolenieTechniczne.Geo.CrossCutting.Dtos;

public class CityDto
{
    public Guid Id { get; set; }
    
    [LocalizedStringRequiredAttribute]
    [LocalizedStringLength(32)]
    public LocalizedString Name { get; set; }
    
    [Required]
    public Guid CountryId { get; set; }
}