namespace przykladowy_1_client.Dtos;

public class ExternalCarServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public bool isActive { get; set; }
}