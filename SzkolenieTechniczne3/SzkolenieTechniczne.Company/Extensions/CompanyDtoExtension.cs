using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using Entities = SzkolenieTechniczne.Company.Storage.Entities;
namespace SzkolenieTechniczne.Company.Extensions
{
    public static class CompanyDtoExtension
    {
        public static Entities.Company ToEntity(this CompanyDto dto)
        {
            return new Entities.Company
            {
                Id = dto.Id,
                Name = dto.Name,
                NIP = dto.NIP,
                REGON = dto.REGON,
                PhoneNumber = dto.PhoneNumber,
                PhoneDirectional = dto.PhoneDirectional,
                Address = new Entities.CompanyAddress
                {
                    CompanyId = dto.Id,
                    FlatNumber = dto.FlatNumber,
                    District = dto.District,
                    HouseNumber = dto.HouseNumber,
                    Post = dto.Post,
                    Province = dto.Province,
                    Street = dto.Street,
                    City =  dto.City,
                    Community = dto.Community,
                    CountryId = dto.CountryId
                }
                
            };

        }
    }
}
