using przykladowy_1_client.Dtos;
using przykladowy_1_client.Entities;

namespace przykladowy_1_client.Extensions;

public static class CreateClientDtoExtension
{
    public static Client ToEntity(this CreateClientDto dto)
    {
        return new Client
        {
            Id = dto.Id,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            CreatedAt = dto.CreatedAt,
            LicensePlate = dto.LicensePlate,
            CarServiceId = dto.CarServiceId,
        };
    }
}