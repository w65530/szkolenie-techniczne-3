

using System;
using System.ComponentModel.DataAnnotations;
using SzkolenieTechniczne.Company.CrossCutting.Enums;

namespace SzkolenieTechniczne.Company.CrossCutting.Dtos
{
    public class JobPositionDto
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; } = null!;

        [StringLength(1024)]
        public string? Description { get; set; }

        [Required]
        [Range(1, 999)]
        public short WorkingHours { get; set; }


        [Required]
        [Range(1, 9999999.99)]
        public decimal GrossSalary { get; set; }

        public EmploymentType? EmploymentType { get; set; }
    }


}
