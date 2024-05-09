using SzkolenieTechniczne.Company.CrossCutting.Dtos;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class CompanyExtension
    {
        public static CompanyDto ToDto(this SzkolenieTechniczne.Company.Storage.Entities.Company enity)
        {
            return new CompanyDto
            {
                Id = enity.Id,
                Name = enity.Name,
                NIP = enity.NIP,
                REGON = enity.REGON,
                PhoneNumber = enity.PhoneNumber,
                PhoneDirectional = enity.PhoneDirectional,
                Address = string.Format("{0}{1}", enity.Address.City, enity.Address.District),
                FlatNumber = enity.Address.FlatNumber,
                District = enity.Address.District,
                HouseNumber = enity.Address.HouseNumber,
                Post = enity.Address.Post,
                Province = enity.Address.Province,
                Street = enity.Address.Street,
                City = enity.Address.City,
                Community = enity.Address.Community,
                CountryId = enity.Address.CountryId
            };
        }
    }
}
