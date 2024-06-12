namespace przykladowy_1_client.Dtos;

public class CreateClientDto
{
    public int Id { get; set; }
    
    public string Email { get; set; } = null!;
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    
    public string LicensePlate { get; set; } = null!;
    
    public int CarServiceId { get; set; }
}