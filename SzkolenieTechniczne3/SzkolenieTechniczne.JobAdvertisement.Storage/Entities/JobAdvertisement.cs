using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.JobAdvertisement.Storage.Entities
{
    [Table("JobAdvertisements", Schema = "JobAdvertisement")]
    public class JobAdvertisement : BaseEntity
    {
        public Guid JobPositionExternalId { get; set; }
        public string JobPositionName { get; set; }

        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int TargetBoth { get; set; }
        public int? TargetMale { get; set; }
        public int? TargetFemale { get; set; }
        public DateTime? WorkStartDate { get; set; }


        public ICollection<JobAdvertisementTranslation> Translations { get; set; }
    }
}
