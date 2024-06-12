using Microsoft.AspNetCore.Mvc;
using przykladowy_1_cars.Dtos;
using przykladowy_1_cars.Services;

namespace przykladowy_1_cars.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarServiceController : ControllerBase
{
    private readonly CarServiceService _carServiceService;
    
    public CarServiceController(CarServiceService carServiceService)
    {
        _carServiceService = carServiceService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCarServices()
    {
        var carServices = await _carServiceService.GetCarServices();
        
        return Ok(carServices);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarService(int id)
    {
        var carService = await _carServiceService.GetCarService(id);
        
        return Ok(carService);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCarService(CarServiceDto carServiceDto)
    {
        var createdCarService = await _carServiceService.CreateCarService(carServiceDto);
        
        return CreatedAtAction(nameof(GetCarService), new { id = createdCarService.Id }, createdCarService);
    }
}