using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Common.Storage.Entities;
using SzkolenieTechniczne.Company.CrossCutting.Enums;

namespace SzkolenieTechniczne.Company.Storage.Entities
{
    [Table("JobPositions", Schema = "Company")]
    public class JobPosition : BaseEntity
    {
        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        [MaxLength(256)]
        public string Name { get; set; } = null!;

        [MaxLength(1024)]
        [Required]
        public string Description { get; set; }

        [Required]
        public decimal GrossSalary { get; set; }

        public EmploymentType? EmploymentType { get; set; }

        [Required]
        public short WorkingWeekHours { get; set; }
    }
}
