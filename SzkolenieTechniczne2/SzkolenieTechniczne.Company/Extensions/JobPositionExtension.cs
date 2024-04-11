using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class JobPositionExtension
    {
        public static JobPositionDto ToDto(this JobPosition entity)
        {
            return new JobPositionDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                Name = entity.Name,
                Description = entity.Description,
                WorkingHours = entity.WorkingWeekHours,
                GrossSalary = entity.GrossSalary,
                EmploymentType = entity.EmploymentType
            };
        }
    }
}