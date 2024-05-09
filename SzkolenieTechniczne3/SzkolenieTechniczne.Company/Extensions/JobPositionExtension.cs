using SzkolenieTechniczne.Company.CrossCutting.Dtos;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class JobPositionExtension
    {
        public static JobPositionDto ToDto(this SzkolenieTechniczne.Company.Storage.Entities.JobPosition enity)
        {
            return new JobPositionDto
            {
                Id = enity.Id,
                Name = enity.Name,
               CompanyId = enity.CompanyId,
               WorkingWeekHours = enity.WorkingWeekHours,
               GrossSalary = enity.GrossSalary,
               EmploymentType = enity.EmploymentType,
               Description = enity.Description,
               WorkingHours = enity.WorkingHours
            };
        }
    }
}
