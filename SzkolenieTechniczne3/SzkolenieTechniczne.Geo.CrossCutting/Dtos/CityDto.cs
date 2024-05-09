using System;
using System.ComponentModel.DataAnnotations;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.CommonCrossCutting.ValidationAttributes;

namespace SzkolenieTechniczne.Geo.CrossCutting.Dtos
{
    public class CityDto
    {
        public Guid Id { get; set; }

        [Required]
        [LocalizedStringRequired]
        [LocalizedStringLength(255)]
        public LocalizedString Name { get; set; } = null!;

        [Required]
        [NotDefault]
        public Guid CountryId { get; set; }

    }
}
