using System.ComponentModel.DataAnnotations;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Common.CrossCutting.ValidationAttributes;

namespace SzkolenieTechniczne.Geo.CrossCutting.Dtos;

public class CountryDto
{
    public Guid Id { get; set; }
    
    [LocalizedStringRequiredAttribute]
    [LocalizedStringLength(32)]
    public LocalizedString Name { get; set; }
    
    [MaxLength(3)]
    [MinLength(2)]
    [Required]
    public string Alpha3Code { get; set; }
}