using kolokwium_api.Dtos;
using kolokwium_api.Entities;

namespace kolokwium_api.Extensions;

public class CompanyExtension
{
    public static CompanyDto ToDto(Company company)
    {
        return new CompanyDto
        {
            Id = company.Id,
            Name = company.Name,
            PhoneNumber = company.PhoneNumber,
            NIP = company.NIP,
            REGON = company.REGON,
            City = company.Address.City,
            Street = company.Address.Street,
            FlatNumber = company.Address.FlatNumber,
            HouseNumber = company.Address.HouseNumber
        };
    }
}