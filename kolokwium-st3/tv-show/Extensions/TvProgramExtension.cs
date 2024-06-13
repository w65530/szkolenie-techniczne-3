using tv_show.Dtos;
using tv_show.Entities;

namespace tv_show.Extensions;

public static class TvProgramExtension
{
    public static TvProgramDto ToDto(this TvProgram tvProgram)
    {
        return new TvProgramDto
        {
            Id = tvProgram.Id,
            Name = tvProgram.Name
        };
    }
}