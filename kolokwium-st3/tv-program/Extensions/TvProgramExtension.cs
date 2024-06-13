using tv_program.Dtos;
using tv_program.Entities;

namespace tv_program.Extensions;

public static class TvProgramExtension
{
    public static TvProgramDto ToDto(this TvProgram tvProgram)
    {
        return new TvProgramDto
        {
            Id = tvProgram.Id,
            Name = tvProgram.Name,
            CreatedAt = tvProgram.CreatedAt,
            IsActive = tvProgram.IsActive
        };
    }
}