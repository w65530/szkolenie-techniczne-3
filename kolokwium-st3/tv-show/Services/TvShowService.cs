using Microsoft.EntityFrameworkCore;
using tv_show.Dtos;
using tv_show.Extensions;

namespace tv_show.Services;

public class TvShowService
{
    private readonly TvShowDbContext _context;
    
    public TvShowService(TvShowDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TvShowDto>> GetTvShows()
    {
        return await _context.TvShows
            .Select(tvShow => tvShow.ToDto())
            .ToListAsync();
    }
    
    public async Task<TvShowDto> GetTvShow(int id)
    {
        var tvShow = await _context.TvShows.FindAsync(id);
        
        return tvShow == null ? new TvShowDto() : tvShow.ToDto();
    }
    
    public async Task<TvShowDto> CreateTvShow(TvShowDto dto)
    {
        var entity = dto.ToEntity();
        await _context.TvShows.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return dto;
    }
}