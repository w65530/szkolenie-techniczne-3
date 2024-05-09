﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Company.Storage.Entities
{
    [Table("Countries", Schema = "Dictionaries")]
    public class Country : BaseEntity, IExternalSourceEntity
    {
        [MaxLength(3)]
        [MinLength(2)]
        [Required]
        public string Alpha3Code { get; set; } = null!;

        public string ExternalSourceName { get; set; }

        public string ExternalId { get; set; }

        public DateTime? LastSynchronizedOn { get; set; }

        public ICollection<CountryTranslation> Translations { get; set; } = new List<CountryTranslation>();
    }
}
