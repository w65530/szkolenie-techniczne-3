using tv_show.Dtos;
using tv_show.Entities;

namespace tv_show.Extensions;

public static class TvShowExtension
{
    public static TvShowDto ToDto(this TvShow tvShow)
    {
        return new TvShowDto
        {
            Id = tvShow.Id,
            Description = tvShow.Description,
            Title = tvShow.Title,
            CreatedAt = tvShow.CreatedAt,
            StartDate = tvShow.StartDate,
            EndDate = tvShow.EndDate,
            TvProgramId = tvShow.TvProgramId
        };
    }
}