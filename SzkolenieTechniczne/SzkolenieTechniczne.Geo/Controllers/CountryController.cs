using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Services;

namespace SzkolenieTechniczne.Geo.Controllers;

[Route("/geo")]
public class CountryController : ControllerBase
{
    private readonly CountryService _countryService;

    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("countries")]
    public async Task<IEnumerable<CountryDto>> Read()
    {
        return await _countryService.Get();
    }

    [HttpGet("countries/{id}")]
    public async Task<IActionResult> ReadById(Guid id)
    {
        var countryDto = await _countryService.GetById(id);

        if (countryDto == null) return NotFound();

        return Ok(countryDto);
    }

    [HttpPost("country")]
    public async Task<IActionResult> Create([FromBody] CountryDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var operationResult = await _countryService.Create(dto);

        return Ok(operationResult.Result);
    }
}