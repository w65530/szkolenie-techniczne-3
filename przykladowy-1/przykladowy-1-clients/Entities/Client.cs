using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace przykladowy_1_client.Entities;

[Table("Clients", Schema = "Client")]
public class Client
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;
    
    [Required]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    [MaxLength(8)]
    public string LicensePlate { get; set; } = null!;
    
    [Required]
    public int CarServiceId { get; set; }
    
    public CarService CarService { get; set; } = null!;
}