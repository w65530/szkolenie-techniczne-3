using Microsoft.AspNetCore.Mvc;
using tv_show.Dtos;
using tv_show.Services;

namespace tv_show.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TvShowController : ControllerBase
{
    private readonly TvShowService _tvShowService;
    
    public TvShowController(TvShowService tvShowService)
    {
        _tvShowService = tvShowService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTvShows()
    {
        var tvShows = await _tvShowService.GetTvShows();
        
        return Ok(tvShows);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTvShow(int id)
    {
        var tvShow = await _tvShowService.GetTvShow(id);
        
        return Ok(tvShow);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTvShow(TvShowDto tvShowDto)
    {
        var createdTvShow = await _tvShowService.CreateTvShow(tvShowDto);
        
        return Ok(createdTvShow);
    }
}