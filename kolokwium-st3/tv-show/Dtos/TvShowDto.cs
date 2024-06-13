namespace tv_show.Dtos;

public class TvShowDto
{
    public int Id { get; set; }
    
    public string Description { get; set; } = null!;
    
    public string Title { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public int TvProgramId { get; set; }
}