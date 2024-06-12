using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace przykladowy_1_client.Entities;

[Table("CarServices", Schema = "Client")]
public class CarService
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int CarServiceId { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = null!;
}