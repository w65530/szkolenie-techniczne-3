using kolokwium_api.Dtos;
using kolokwium_api.Entities;

namespace kolokwium_api.Extensions;

public class CompanyDtoExtension
{
    public static Company ToEntity(CompanyDto dto)
    {
        return new Company
        {
            Name = dto.Name,
            PhoneNumber = dto.PhoneNumber,
            NIP = dto.NIP,
            REGON = dto.REGON,
            Address = new CompanyAddress
            {
                City = dto.City,
                Street = dto.Street,
                FlatNumber = dto.FlatNumber,
                HouseNumber = dto.HouseNumber
            }
        };
    }
}