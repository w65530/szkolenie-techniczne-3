using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.CommonCrossCutting.Dtos;
using SzkolenieTechniczne.CommonCrossCutting.ValidationAttributes;

namespace SzkolenieTechniczne.JobAdvertisement.CrossCutting.Dtos
{
    public class JobAdvertisementDto
    {
        public Guid Id { get; set; }

        public Guid JobPositionExternalId { get; set; }
        public string JobPositionName { get; set; }

        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int TargetBoth { get; set; }
        public int? TargetMale { get; set; }
        public int? TargetFemale { get; set; }
        public DateTime? WorkStartDate { get; set; }

        [LocalizedStringRequiredAttribute]
        [LocalizedStringLengthAttribute(32)]
        public LocalizedString Name { get; set; }

        public LocalizedString Responsibilities { get; set; }
        public LocalizedString  Description { get; set; }
        


    }
}
