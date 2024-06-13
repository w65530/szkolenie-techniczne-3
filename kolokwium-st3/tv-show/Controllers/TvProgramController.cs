using Microsoft.AspNetCore.Mvc;
using tv_show.Dtos;
using tv_show.Services;

namespace tv_show.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TvProgramController : ControllerBase
{
    private readonly TvProgramService _tvProgramService;
    
    public TvProgramController(TvProgramService tvProgramService)
    {
        _tvProgramService = tvProgramService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTvPrograms()
    {
        var tvPrograms = await _tvProgramService.GetTvPrograms();
        
        return Ok(tvPrograms);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTvProgram(int id)
    {
        var tvProgram = await _tvProgramService.GetTvProgram(id);
        
        return Ok(tvProgram);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTvProgram(TvProgramDto tvProgramDto)
    {
        var createdTvProgram = await _tvProgramService.CreateTvProgram(tvProgramDto);

        return Ok(createdTvProgram);
    }
}