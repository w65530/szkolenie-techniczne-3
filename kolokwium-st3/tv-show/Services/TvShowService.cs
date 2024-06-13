using Microsoft.EntityFrameworkCore;
using tv_show.Dtos;
using tv_show.Extensions;
using tv_show.Resolvers;

namespace tv_show.Services;

public class TvShowService
{
    private readonly TvShowDbContext _context;
    private readonly TvProgramResolver _tvProgramResolver;
    
    public TvShowService(TvShowDbContext context, TvProgramResolver tvProgramResolver)
    {
        _context = context;
        _tvProgramResolver = tvProgramResolver;
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
        
        var tvProgram = await ResolveAndAddTvProgram(entity.TvProgramId);

        if (tvProgram != null!)
        {
            if (!await CheckIfTvProgramIsActive(entity.TvProgramId))
            {
                throw new InvalidOperationException("TV Program is not active.");
            }
        }
        
        if (!await CheckIfCanCreateNewTvShow(entity.TvProgramId, entity.StartDate, entity.EndDate))
        {
            throw new InvalidOperationException("A TV show with the given program ID already exists within the specified date range.");
        }
        
        await _context.TvShows.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return dto;
    }
    
    private async Task<bool> CheckIfCanCreateNewTvShow(int tvProgramId, DateTime startDate, DateTime endDate)
    {
        var existingTvShows = await _context.TvShows
            .Where(show => show.TvProgramId == tvProgramId)
            .Where(show => ((startDate >= show.StartDate && startDate <= show.EndDate) ||
                            (endDate >= show.StartDate && endDate <= show.EndDate) ||
                            (startDate <= show.StartDate && endDate >= show.EndDate)))
            .ToListAsync();
        
        return existingTvShows.Count == 0;
    }
    
    private async Task<bool> CheckIfTvProgramIsActive(int tvProgramId)
    {
        return await _tvProgramResolver.CheckIfTvProgramIsActive(tvProgramId);
    }
    
    private async Task<TvProgramDto> ResolveAndAddTvProgram(int tvProgramId)
    {
        var tvProgram = await _tvProgramResolver.ResolveTvProgramAsync(tvProgramId);
        
        if (tvProgram == null)
        {
            throw new InvalidOperationException("TV Program not found.");
        }
        
        var tvPrograms = await _context.TvPrograms.FindAsync(tvProgramId);
        
        if (tvPrograms == null)
        {
            await _context.TvPrograms.AddAsync(tvProgram.ToEntity());
        }
        else if (tvPrograms.Name != tvProgram.Name)
        {
            tvPrograms.Name = tvProgram.Name;
            await _context.SaveChangesAsync();
        }
        
        return tvProgram;
    }
}