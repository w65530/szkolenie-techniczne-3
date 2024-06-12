namespace przykladowy_1_cars.Dtos;

public class CarServiceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public bool isActive { get; set; }
}