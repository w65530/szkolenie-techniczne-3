using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class CompanyDtoExtension
    {
        public static Storage.Entities.Company ToEntity(this CompanyDto dto)
        {
            return new Storage.Entities.Company
            {
                Id = dto.Id,
                Name = dto.Name,
                PhoneDirectional = dto.PhoneDirectional,
                PhoneNumber = dto.PhoneNumber,
                NIP = dto.NIP,
                REGON = dto.REGON,
                Address = new CompanyAddress
                {
                    Post = dto.Post,
                    Province = dto.Province,
                    District = dto.District,
                    Community = dto.Community,
                    City = dto.City,
                    Street = dto.Street,
                    FlatNumber = dto.FlatNumber,
                    HouseNumber = dto.HouseNumber
                }
            };
        }
    }
}