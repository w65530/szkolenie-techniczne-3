using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Company.Storage.Entities
{
    [Table("CountryTranslations", Schema = "Dictionaries")]
    public class CountryTranslation : BaseTranslation
    {
        [ForeignKey("Country")]
        public Guid CountryId { get; set; }

        [MaxLength(64)]
        [MinLength(2)]
        [Required]
        public string Name { get; set; } = null!;
    }
}
