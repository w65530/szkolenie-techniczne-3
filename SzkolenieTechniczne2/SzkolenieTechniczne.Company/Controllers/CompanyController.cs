using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Services;

namespace SzkolenieTechniczne.Company.Controllers
{
    [Route("/company")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;
        
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }
        
        [HttpGet("companies")]
        public async Task<IEnumerable<CompanyDto>> Read() => await _companyService.Get();
        
        [HttpGet("companies/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var companyDto = await _companyService.GetById(id);
            
            if (companyDto == null)
            {
                return NotFound();
            }
            
            return Ok(companyDto);
        }
        
        [HttpPost("company")]
        public async Task<IActionResult> Create([FromBody] CompanyDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var operationResult = await _companyService.Create(dto);

            return Ok(operationResult.Result);
        }
    }
}