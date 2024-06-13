using Microsoft.EntityFrameworkCore;
using tv_show.Dtos;
using tv_show.Extensions;

namespace tv_show.Services;

public class TvProgramService
{
    private readonly TvShowDbContext _context;
    
    public TvProgramService(TvShowDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TvProgramDto>> GetTvPrograms()
    {
        return await _context.TvPrograms
            .Select(tvProgram => tvProgram.ToDto())
            .ToListAsync();
    }
    
    public async Task<TvProgramDto> GetTvProgram(int id)
    {
        var tvProgram = await _context.TvPrograms.FindAsync(id);
        
        return tvProgram == null ? new TvProgramDto() : tvProgram.ToDto();
    }
    
    public async Task<TvProgramDto> CreateTvProgram(TvProgramDto dto)
    {
        var entity = dto.ToEntity();
        await _context.TvPrograms.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return dto;
    }
}