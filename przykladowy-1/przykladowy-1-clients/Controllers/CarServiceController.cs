using Microsoft.AspNetCore.Mvc;
using przykladowy_1_client.Dtos;
using przykladowy_1_client.Services;

namespace przykladowy_1_client.Controllers;

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
    public async Task<ActionResult<CarServiceDto>> GetCarServiceById(int id)
    {
        var carService = await _carServiceService.GetCarServiceById(id);
        
        if (carService == null)
        {
            return NotFound();
        }
        
        return Ok(carService);
    }
    
    [HttpPost]
    public async Task<ActionResult<CarServiceDto>> CreateCarService(CarServiceDto dto)
    {
        var carService = await _carServiceService.CreateCarService(dto);

        return Ok(carService);
    }
}