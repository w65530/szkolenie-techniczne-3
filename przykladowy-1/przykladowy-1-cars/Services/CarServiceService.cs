using Microsoft.EntityFrameworkCore;
using przykladowy_1_cars.Dtos;
using przykladowy_1_cars.Extensions;

namespace przykladowy_1_cars.Services;

public class CarServiceService
{
    private readonly CarServiceDbContext _context;
    
    public CarServiceService(CarServiceDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<CarServiceDto>> GetCarServices()
    {
        return await _context.CarServices
            .Select(carService => carService.ToDto())
            .ToListAsync();
    }
    
    public async Task<CarServiceDto> GetCarService(int id)
    {
        var carService = await _context.CarServices.FindAsync(id);
        
        return carService == null ? new CarServiceDto() : carService.ToDto();
    }
    
    public async Task<CarServiceDto> CreateCarService(CarServiceDto carServiceDto)
    {
        var carService = carServiceDto.ToEntity();
        await _context.CarServices.AddAsync(carService);
        await _context.SaveChangesAsync();
        
        return carServiceDto;
    }
}