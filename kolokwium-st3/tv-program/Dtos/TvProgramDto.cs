namespace tv_program.Dtos;

public class TvProgramDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }
}