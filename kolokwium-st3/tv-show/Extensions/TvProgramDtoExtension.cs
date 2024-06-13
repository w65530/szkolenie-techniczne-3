using tv_show.Dtos;
using tv_show.Entities;

namespace tv_show.Extensions;

public static class TvProgramDtoExtension
{
    public static TvProgram ToEntity(this TvProgramDto tvProgramDto)
    {
        return new TvProgram
        {
            Id = tvProgramDto.Id,
            Name = tvProgramDto.Name
        };
    }
}