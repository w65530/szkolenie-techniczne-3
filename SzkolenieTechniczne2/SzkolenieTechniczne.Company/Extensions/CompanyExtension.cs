using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class CompanyExtension
    {
        public static CompanyDto ToDto(this Storage.Entities.Company entity)
        {
            return new CompanyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                PhoneDirectional = entity.PhoneDirectional,
                PhoneNumber = entity.PhoneNumber,
                NIP = entity.NIP,
                REGON = entity.REGON,
                Post = entity.Address.Post,
                Province = entity.Address.Province,
                District = entity.Address.District,
                Community = entity.Address.Community,
                City = entity.Address.City,
                Street = entity.Address.Street,
                FlatNumber = entity.Address.FlatNumber,
                HouseNumber = entity.Address.HouseNumber
            };
        }
    }
}