using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.Geo.Services;
using SzkolenieTechniczne.Geo.Storage.Entities;
using SzkolenieTechniczne.Geo.Storage;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using System.Linq;
using System.Collections.Generic;

namespace SzkolenieTechniczne.Geo.Controllers
{
    [Route("/geo")]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;

        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        /// <summary>
        /// Gets list of cities
        /// </summary>
        /// <returns></returns>
        [HttpGet("cities")]
        public async Task<IEnumerable<CityDto>> Read() => await _cityService.Get();

        /// <summary>
        /// Gets city information by identifier
        /// </summary>
        /// <param name="id">Identifier of the city</param>
        /// <returns></returns>
        [HttpGet("cities/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var cityDto = await _cityService.GetById(id);

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
        [HttpPost("city")]
        public async Task<IActionResult> Create([FromBody] CityDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _cityService.Create(dto);

            return Ok(operationResult.Result);
        }
    }
}
