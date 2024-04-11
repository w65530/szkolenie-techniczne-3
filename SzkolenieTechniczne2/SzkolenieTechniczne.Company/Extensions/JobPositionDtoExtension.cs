using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class JobPositionDtoExtension
    {
        public static JobPosition ToEntity(this JobPositionDto dto)
        {
            return new JobPosition
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                Name = dto.Name,
                Description = dto.Description,
                WorkingWeekHours = dto.WorkingHours,
                GrossSalary = dto.GrossSalary,
                EmploymentType = dto.EmploymentType
            };
        }
    }
}