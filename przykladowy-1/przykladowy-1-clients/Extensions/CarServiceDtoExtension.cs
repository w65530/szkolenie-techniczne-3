using przykladowy_1_client.Dtos;
using przykladowy_1_client.Entities;

namespace przykladowy_1_client.Extensions;

public static class CarServiceDtoExtension
{
    public static CarService ToEntity(this CarServiceDto dto)
    {
        return new CarService
        {
            Id = dto.Id,
            CarServiceId = dto.CarServiceId,
            Name = dto.Name,
        };
    }
}