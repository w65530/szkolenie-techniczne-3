using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.JobAdvertisement.Storage.Entities
{
    [Index(nameof(Name), IsUnique = false)]
    [Table("JobAdvertisementTranslations", Schema = "JobAdvertisement")]
    public class JobAdvertisementTranslation : BaseTranslation
    {

        [MaxLength(256)]
        [MinLength(2)]
        [Required]
        public string Name { get; set; } = null!;

        [MaxLength(3000)]
        public string? Responsibilities { get; set; }

        [MaxLength(3000)]
        public string Description { get; set; }
    }
}
