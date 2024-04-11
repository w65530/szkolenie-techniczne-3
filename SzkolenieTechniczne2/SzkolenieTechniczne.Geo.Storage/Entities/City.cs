using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Geo.Storage.Entities
{
    [Table("Cities", Schema = "Geo")]
    public class City : BaseEntity
    {
        [Required]
        public Guid CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<CityTranslation> Translations { get; set; }
    }
}
