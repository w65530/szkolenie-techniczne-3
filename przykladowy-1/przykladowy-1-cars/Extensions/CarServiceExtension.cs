using przykladowy_1_cars.Dtos;
using przykladowy_1_cars.Entities;

namespace przykladowy_1_cars.Extensions;

public static class CarServiceExtension
{
    public static CarServiceDto ToDto(this CarService carService)
    {
        return new CarServiceDto
        {
            Id = carService.Id,
            Name = carService.Name,
            CreatedAt = carService.CreatedAt,
            isActive = carService.isActive
        };
    }
}