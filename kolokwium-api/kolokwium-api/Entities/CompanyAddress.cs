using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace kolokwium_api.Entities;

[Table("CompanyAddresses", Schema = "Company")]
public class CompanyAddress
{
    [Key]
    public int Id { get; set; }
    
    public int CompanyId { get; set; }
    
    [JsonIgnore]
    public Company Company { get; set; } = null!;
    
    [Required]
    [MaxLength(255)]
    public string City { get; set; } = null!;
    
    [Required]
    [MaxLength(255)]
    public string Street { get; set; } = null!;
    
    public string? FlatNumber { get; set; }
    
    public string? HouseNumber { get; set; }
}