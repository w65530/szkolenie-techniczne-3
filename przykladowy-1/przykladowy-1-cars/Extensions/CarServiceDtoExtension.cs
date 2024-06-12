using przykladowy_1_cars.Dtos;
using przykladowy_1_cars.Entities;

namespace przykladowy_1_cars.Extensions;

public static class CarServiceDtoExtension
{
    public static CarService ToEntity(this CarServiceDto carServiceDto)
    {
        return new CarService
        {
            Id = carServiceDto.Id,
            Name = carServiceDto.Name,
            CreatedAt = carServiceDto.CreatedAt,
            isActive = carServiceDto.isActive
        };
    }
}