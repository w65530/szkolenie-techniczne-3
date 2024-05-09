using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SzkolenieTechniczne.Candidate.Api.Services;
using SzkolenieTechniczne.Candidate.CrossCutting.Dtos;

namespace SzkolenieTechniczne.Candidate.Api.Controllers
{
    public class CandidateController : ControllerBase
    {
        private readonly CandidateService _candidateService;

        public CandidateController(CandidateService companyService)
        {
            _candidateService = companyService;
        }

        /// <summary>
        /// Gets list of companies
        /// </summary>
        /// <returns></returns>
        [HttpGet("candidates")]
        public async Task<IEnumerable<CandidateDto>> Read() => await _candidateService.Get();

        /// <summary>
        /// Gets city information by identifier
        /// </summary>
        /// <param name="id">Identifier of the city</param>
        /// <returns></returns>
        [HttpGet("candidates/{id}")]
        public async Task<IActionResult> ReadById(Guid id)
        {
            var companyDto = await _candidateService.GetById(id);

            if (companyDto == null)
            {
                return NotFound();
            }

            return Ok(companyDto);
        }

        /// <summary>
        /// Creates a new city entry. The identifier of the record will be automatically generated.
        /// </summary>
        /// <param name="dto">Data transfer object describing city</param>
        /// <returns></returns>
        [HttpPost("candidate")]
        public async Task<IActionResult> Create([FromBody] CandidateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _candidateService.Create(dto);

            return Ok(operationResult.Result);
        }
    }
}

