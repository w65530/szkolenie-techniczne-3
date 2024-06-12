using przykladowy_1_client.Dtos;
using przykladowy_1_client.Entities;

namespace przykladowy_1_client.Extensions;

public static class CarServiceExtension
{
    public static CarServiceDto ToDto(this CarService carService)
    {
        return new CarServiceDto
        {
            Id = carService.Id,
            CarServiceId = carService.CarServiceId,
            Name = carService.Name
        };
    }
}