using Microsoft.EntityFrameworkCore;
using przykladowy_1_client.Dtos;
using przykladowy_1_client.Extensions;

namespace przykladowy_1_client.Services;

public class CarServiceService
{
    private readonly ClientServiceDbContext _context;
    
    public CarServiceService(ClientServiceDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<CarServiceDto>> GetCarServices()
    {
        var carServices = await _context.CarServices.ToListAsync();
        
        return carServices.Select(cs => cs.ToDto());
    }
    
    public async Task<CarServiceDto?> GetCarServiceById(int id)
    {
        var carService = await _context.CarServices.FirstOrDefaultAsync(cs => cs.Id == id);
        
        return carService?.ToDto();
    }
    
    public async Task<CarServiceDto?> CreateCarService(CarServiceDto dto)
    {
        var carService = dto.ToEntity();
        
        await _context.CarServices.AddAsync(carService);
        await _context.SaveChangesAsync();

        return dto;
    }
}