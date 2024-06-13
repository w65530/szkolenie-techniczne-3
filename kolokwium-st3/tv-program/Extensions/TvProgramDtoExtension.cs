using tv_program.Dtos;
using tv_program.Entities;

namespace tv_program.Extensions;

public static class TvProgramDtoExtension
{
    public static TvProgram ToEntity(this TvProgramDto tvProgramDto)
    {
        return new TvProgram
        {
            Id = tvProgramDto.Id,
            Name = tvProgramDto.Name,
            CreatedAt = tvProgramDto.CreatedAt,
            IsActive = tvProgramDto.IsActive
        };
    }
}