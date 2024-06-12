using przykladowy_1_client.Dtos;
using przykladowy_1_client.Entities;

namespace przykladowy_1_client.Extensions;

public static class ClientDtoExtension
{
    public static Client ToEntity(this ClientDto dto)
    {
        return new Client
        {
            Id = dto.Id,
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            CreatedAt = dto.CreatedAt,
            LicensePlate = dto.LicensePlate,
            CarService = dto.CarService.ToEntity(),
        };
    }
}