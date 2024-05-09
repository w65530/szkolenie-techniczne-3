using Microsoft.AspNetCore.Mvc;
using SzkolenieTechniczne.Geo.Services;
using System.Threading.Tasks;
using System;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using System.Collections.Generic;

namespace SzkolenieTechniczne.Geo.Controllers
{
    [Route("/geo")]
    public class CountryController : ControllerBase
    {
        private readonly CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Gets list of countries
        /// </summary>
        /// <returns></returns>
        [HttpGet("countries")]
        public async Task<IEnumerable<CountryDto>> Read() => await _countryService.Get();

        /// <summary>
        /// Gets country information by identifier
        /// </summary>
        /// <param name="id">Identifier of the country</param>
        /// <returns></returns>
        [HttpGet("countries/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var cityDto = await _countryService.GetById(id);

            if (cityDto == null)
            {
                return NotFound();
            }

            return Ok(cityDto);
        }

        /// <summary>
        /// Creates a new contry. The identifier of the record will be automatically generated.
        /// </summary>
        /// <param name="dto">Data transfer object describing city</param>
        /// <returns></returns>
        [HttpPost("country")]
        public async Task<IActionResult> Create([FromBody] CountryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _countryService.Create(dto);

            return Ok(operationResult.Result);
        }
    }
}
