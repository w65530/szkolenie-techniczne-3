using przykladowy_1_client.Dtos;
using przykladowy_1_client.Entities;

namespace przykladowy_1_client.Extensions;

public static class ClientExtension
{
    public static ClientDto ToDto(this Client client)
    {
        return new ClientDto
        {
            Id = client.Id,
            Email = client.Email,
            FirstName = client.FirstName,
            LastName = client.LastName,
            CreatedAt = client.CreatedAt,
            LicensePlate = client.LicensePlate,
            CarService = client.CarService.ToDto(),
        };
    }
    
    public static CreateClientDto ToCreateDto(this Client client)
    {
        return new CreateClientDto
        {
            Id = client.Id,
            Email = client.Email,
            FirstName = client.FirstName,
            LastName = client.LastName,
            CreatedAt = client.CreatedAt,
            LicensePlate = client.LicensePlate,
            CarServiceId = client.CarServiceId,
        };
    }
}