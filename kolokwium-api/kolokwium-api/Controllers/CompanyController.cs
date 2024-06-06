using kolokwium_api.Dtos;
using kolokwium_api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_api.Controllers;

public class CompanyController : ControllerBase
{
    private readonly CompanyService _companyService;
    
    public CompanyController(CompanyService companyService)
    {
        _companyService = companyService;
    }
    
    [HttpGet("companies/{id}")]
    public async Task<IActionResult> ReadById(int id)
    {
        var company = await _companyService.GetById(id);
        
        return company == null ? NotFound() : Ok(company);
    }
    
    [HttpGet("companies")]
    public async Task<IActionResult> ReadAll()
    {
        var companies = await _companyService.Get();
        
        return Ok(companies);
    }
    
    [HttpPost("companies")]
    public async Task<IActionResult> Create([FromBody] CompanyDto companyDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var company = await _companyService.Create(companyDto);

        return Ok(company);
    }
    
    [HttpPut("companies/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CompanyDto companyDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var company = await _companyService.Update(id, companyDto);

        return company == null ? NotFound() : Ok(company);
    }
    
    [HttpDelete("companies/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var company = await _companyService.Delete(id);
        
        return company == null ? NotFound() : Ok(company);
    }
}