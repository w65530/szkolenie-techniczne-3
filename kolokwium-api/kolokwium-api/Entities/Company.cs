using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium_api.Entities;

[Table("Companies", Schema = "Company")]
public class Company
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = null!;
    
    [MaxLength(32)]
    public string PhoneNumber { get; set; } = null!;
    
    [MaxLength(32)]
    public string NIP { get; set; } = null!;
    
    [MaxLength(16)]
    public string REGON { get; set; } = null!;
    
    public CompanyAddress Address { get; set; } = null!;
}