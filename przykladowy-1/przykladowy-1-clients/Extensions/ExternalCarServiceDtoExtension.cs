using przykladowy_1_client.Dtos;
using przykladowy_1_client.Entities;

namespace przykladowy_1_client.Extensions;

public static class ExternalCarServiceDtoExtension
{
    public static CarService ToEntity(this ExternalCarServiceDto dto)
    {
        return new CarService
        {
            CarServiceId = dto.Id,
            Name = dto.Name,
        };
    }
}