using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Services;

namespace SzkolenieTechniczne.Company.Controllers
{
    [Route("/company")]
    public class JobPositionController : ControllerBase
    {
        private readonly JobPositionService _jobPositionService;

        public JobPositionController(JobPositionService jobPositionService)
        {
            _jobPositionService = jobPositionService;
        }

        /// <summary>
        /// Gets list of job position
        /// </summary>
        /// <returns></returns>
        [HttpGet("job-positions")]
        public async Task<IEnumerable<JobPositionDto>> Read() => await _jobPositionService.Get();

        /// <summary>
        /// Gets job position information by identifier
        /// </summary>
        /// <param name="id">Identifier of the job position</param>
        /// <returns></returns>
        [HttpGet("job-positions/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var companyDto = await _jobPositionService.GetById(id);

            if (companyDto == null)
            {
                return NotFound();
            }

            return Ok(companyDto);
        }

        /// <summary>
        /// Creates a new job position entry. The identifier of the record will be automatically generated.
        /// </summary>
        /// <param name="dto">Data transfer object describing city</param>
        /// <returns></returns>
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
