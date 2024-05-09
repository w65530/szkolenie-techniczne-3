using SzkolenieTechniczne.Company.CrossCutting.Dtos;

using Entities = SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class JobPositionDtoExtension
    {
        public static Entities.JobPosition ToEntity(this JobPositionDto dto)
        {
            return new Entities.JobPosition
            {
                Id = dto.Id,
                Name = dto.Name,
                CompanyId = dto.CompanyId,
                Description = dto.Description,
                EmploymentType = dto.EmploymentType,
                GrossSalary = dto.GrossSalary,
                WorkingWeekHours = dto.WorkingWeekHours
                
            };
        }
    }
}
