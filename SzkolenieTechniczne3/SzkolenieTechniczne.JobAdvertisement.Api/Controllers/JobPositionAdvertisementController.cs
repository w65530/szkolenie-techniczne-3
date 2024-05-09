using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SzkolenieTechniczne.JobAdvertisement.Api.Services;
using SzkolenieTechniczne.JobAdvertisement.CrossCutting.Dtos;

namespace SzkolenieTechniczne.JobAdvertisement.Api.Controllers
{
    public class JobPositionAdvertisementController : ControllerBase
    {
        private readonly JobPositionAdvertisementService _service;

        public JobPositionAdvertisementController(JobPositionAdvertisementService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets list of cities
        /// </summary>
        /// <returns></returns>
        [HttpGet("advertisements")]
        public async Task<IEnumerable<JobAdvertisementDto>> Read() => await _service.Get();

        /// <summary>
        /// Gets city information by identifier
        /// </summary>
        /// <param name="id">Identifier of the city</param>
        /// <returns></returns>
        [HttpGet("advertisements/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var cityDto = await _service.GetById(id);

            if (cityDto == null)
            {
                return NotFound();
            }

            return Ok(cityDto);
        }

        /// <summary>
        /// Creates a new city entry. The identifier of the record will be automatically generated.
        /// </summary>
        /// <param name="dto">Data transfer object describing city</param>
        /// <returns></returns>
        [HttpPost("advertisement")]
        public async Task<IActionResult> Create([FromBody] JobAdvertisementDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _service.Create(dto);

            return Ok(operationResult.Result);
        }
    }
}
