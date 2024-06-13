using tv_show.Dtos;

namespace tv_show.Resolvers;

public class TvProgramResolver
{
    public const string TvProgramServiceUrl = "http://localhost:5193/api/TvProgram";
    
    private readonly HttpClient _httpClient;

    public TvProgramResolver(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TvProgramDto> ResolveTvProgramAsync(int tvProgramId)
    {
        var response = await _httpClient.GetAsync($"{TvProgramServiceUrl}/{tvProgramId}");

        if (!response.IsSuccessStatusCode)
        {
            return null!;
        }

        var tvProgram = await response.Content.ReadFromJsonAsync<TvProgramDto>();
        
        return tvProgram!;
    }
    
    public async Task<bool> CheckIfTvProgramIsActive(int tvProgramId)
    {
        
        var response = await _httpClient.GetAsync($"{TvProgramServiceUrl}/{tvProgramId}");

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        var tvProgram = await response.Content.ReadFromJsonAsync<ExternalTvProgramDto>();

        return tvProgram != null && tvProgram.IsActive;
    }
}