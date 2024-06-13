using tv_show.Dtos;
using tv_show.Entities;

namespace tv_show.Extensions;

public static class TvShowDtoExtension
{
    public static TvShow ToEntity(this TvShowDto tvShowDto)
    {
        return new TvShow
        {
            Id = tvShowDto.Id,
            Description = tvShowDto.Description,
            Title = tvShowDto.Title,
            CreatedAt = tvShowDto.CreatedAt,
            StartDate = tvShowDto.StartDate,
            EndDate = tvShowDto.EndDate,
            TvProgramId = tvShowDto.TvProgramId
        };
    }
}