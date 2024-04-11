using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Services;

namespace SzkolenieTechniczne.Company.Controllers
{
    [Route("/job-position")]
    public class JobPositionController : ControllerBase
    {
        private readonly JobPositionService _jobPositionService;
        
        public JobPositionController(JobPositionService jobPositionService)
        {
            _jobPositionService = jobPositionService;
        }
        
        [HttpGet("job-positions")]
        public async Task<IEnumerable<JobPositionDto>> Read() => await _jobPositionService.Get();
        
        [HttpGet("job-positions/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var jobPositionDto = await _jobPositionService.GetById(id);
            
            if (jobPositionDto == null)
            {
                return NotFound();
            }
            
            return Ok(jobPositionDto);
        }

        [HttpPost("job-position")]
        public async Task<IActionResult> Create([FromBody] JobPositionDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _jobPositionService.Create(dto);

            return Ok(operationResult.Result);
        }
    }
}